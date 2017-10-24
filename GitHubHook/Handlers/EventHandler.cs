using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.Models;

namespace GitHubHook.Handlers
{
    public abstract class EventHandler<T> : BaseEventHandler where T : BaseEvent
    {
        public abstract Task<string> HandleEvent(
            APIGatewayProxyRequest request,
            ILambdaContext context,
            string deliveryId,
            T eventPayload);

        public override async Task<string> HandleEvent(
            APIGatewayProxyRequest request,
            ILambdaContext context,
            string deliveryId,
            BaseEvent eventPayload)
        {
            if (eventPayload is T tPayload)
            {
                return await HandleEvent(request, context, deliveryId, tPayload);
            }
            else
            {
                throw new ArgumentException(
                    $"EventHandler expects payload of type '{typeof(T)}', received type '{eventPayload.GetType()}'",
                    nameof(eventPayload));
            }
        }
    }
}
