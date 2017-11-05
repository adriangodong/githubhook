using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.Events;

namespace GitHubHook.Handlers
{
    public class DefaultHandler : BaseEventHandler
    {
        public override Task<string> HandleEvent(
            APIGatewayProxyRequest request,
            ILambdaContext context,
            string deliveryId,
            BaseEvent eventPayload)
        {
            return Task.FromResult(request.Body);
        }
    }
}
