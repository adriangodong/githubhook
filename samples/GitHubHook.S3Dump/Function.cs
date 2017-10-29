using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.S3Dump.Handlers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace GitHubHook.S3Dump
{
    public class Function
    {
        private readonly LambdaHandler lambdaHandler;

        public async Task<APIGatewayProxyResponse> FunctionHandler(
            APIGatewayProxyRequest input,
            ILambdaContext context)
        {
            return await lambdaHandler.Handle(input, context);
        }

        public Function()
        {
            var eventHandlers = new EventHandlersRegistry();
            eventHandlers.RegisterEventHandler<AnyToS3Handler>("ping");
            eventHandlers.RegisterEventHandler<AnyToS3Handler>("milestone");

            lambdaHandler = new LambdaHandler(
                new Authentication(),
                eventHandlers,
                new EventPayloadFactory());
        }
    }
}
