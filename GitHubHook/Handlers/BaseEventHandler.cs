using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.Events;

namespace GitHubHook.Handlers
{
    public abstract class BaseEventHandler
    {
        public abstract Task<string> HandleEvent(
            APIGatewayProxyRequest request,
            ILambdaContext context,
            string deliveryId,
            BaseEvent eventPayload);

        public virtual bool CanHandleEvent(Type type)
        {
            return true;
        }
    }
}
