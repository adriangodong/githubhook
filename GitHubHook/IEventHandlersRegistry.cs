using System.Collections.Generic;
using GitHubHook.Handlers;

namespace GitHubHook
{
    public interface IEventHandlersRegistry
    {
        void RegisterEventHandler<T>(string eventId) where T : BaseEventHandler, new();
        void RegisterEventHandler<T>(string eventId, T handler) where T : BaseEventHandler;
        void RegisterWildcardEventHandler<T>() where T : BaseEventHandler, new();
        void RegisterWildcardEventHandler<T>(T handler) where T : BaseEventHandler;
        IEnumerable<BaseEventHandler> GetEventHandlersOrDefault(string eventId);
    }
}
