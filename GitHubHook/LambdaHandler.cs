using System;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

namespace GitHubHook
{
    public sealed class LambdaHandler
    {

        internal const string XGitHubDeliveryHeaderKey = "X-GitHub-Delivery";
        internal const string XGitHubEventHeaderKey = "X-GitHub-Event";

        private readonly IAuthentication authentication;
        private readonly IEventHandlersRegistry eventHandlers;
        private readonly IEventPayloadFactory eventPayloadFactory;

        public LambdaHandler(
            IAuthentication authentication,
            IEventHandlersRegistry eventHandlers,
            IEventPayloadFactory eventPayloadFactory)
        {
            this.authentication = authentication;
            this.eventHandlers = eventHandlers;
            this.eventPayloadFactory = eventPayloadFactory;
        }

        public async Task<APIGatewayProxyResponse> Handle(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var authenticationResult = authentication.Authenticate(request);
            switch (authenticationResult)
            {
                case AuthenticationResult.Success:
                    context.Logger.Log("DEBUG: Request signature validated");
                    break;
                case AuthenticationResult.SignatureNotRequired:
                    context.Logger.Log("WARNING: Request is not signed");
                    break;
                case AuthenticationResult.HasSignatureButMissingSecretToken:
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 500,
                        Body = "ERROR: Secret token not configured"
                    };
                case AuthenticationResult.InvalidSignature:
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 400,
                        Body = "ERROR: Invalid signature"
                    };
                case AuthenticationResult.InvalidPayload:
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 400,
                        Body = "ERROR: Invalid payload"
                    };
                case AuthenticationResult.MismatchedSignature:
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 401,
                        Body = "ERROR: Mismatched signature"
                    };
                default:
                    throw new NotImplementedException($"Unknown authentication result '{authenticationResult}'");
            }

            if (!request.Headers.TryGetValue(XGitHubDeliveryHeaderKey, out var deliveryId))
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = 400,
                    Body = $"Missing {XGitHubDeliveryHeaderKey} header"
                };
            }

            if (!request.Headers.TryGetValue(XGitHubEventHeaderKey, out var eventId))
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = 400,
                    Body = $"Missing {XGitHubEventHeaderKey} header"
                };
            }

            context.Logger.Log($"DEBUG: Processing delivery {deliveryId} ({eventId})");

            var eventPayload = eventPayloadFactory.CreateEventPayload(eventId, request.Body);
            var handlers = eventHandlers.GetEventHandlersOrDefault(eventPayload);

            var resultBuilder = new StringBuilder();
            foreach (var handler in handlers)
            {
                var result = await handler.HandleEvent(request, context, deliveryId, eventPayload);
                var resultString = $"{handler}:{result}";
                resultBuilder.AppendLine(resultString);
                context.Logger.Log($"DEBUG: {resultString}");
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = resultBuilder.ToString().TrimEnd()
            };
        }

    }
}
