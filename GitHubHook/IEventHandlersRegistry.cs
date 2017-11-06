using System.Collections.Generic;
using GitHubHook.Events;
using GitHubHook.Handlers;

namespace GitHubHook
{
    public interface IEventHandlersRegistry
    {
        void RegisterEventHandler<T>() where T : BaseEventHandler, new();
        void RegisterEventHandler<T>(T handler) where T : BaseEventHandler;
        IEnumerable<BaseEventHandler> GetEventHandlersOrDefault(BaseEvent eventPayload);
    }
}
