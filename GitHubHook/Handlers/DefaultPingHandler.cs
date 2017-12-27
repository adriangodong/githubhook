using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.Events;

namespace GitHubHook.Handlers
{
    public class DefaultPingHandler : EventHandler<PingEvent>
    {
        public override Task<string> HandleEvent(
            APIGatewayProxyRequest request,
            ILambdaContext context,
            string deliveryId,
            PingEvent eventPayload)
        {
            return Task.FromResult(eventPayload.Zen);
        }
    }
}
