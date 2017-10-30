using System.Collections.Generic;
using GitHubHook.Handlers;

namespace GitHubHook
{
    public class EventHandlersRegistry : IEventHandlersRegistry
    {

        internal readonly Dictionary<string, List<BaseEventHandler>> eventHandlers;
        internal readonly List<BaseEventHandler> wildcardEventHandlers;

        public EventHandlersRegistry()
        {
            eventHandlers = new Dictionary<string, List<BaseEventHandler>>();
            wildcardEventHandlers = new List<BaseEventHandler>();
        }

        public void RegisterEventHandler<T>(string eventId)
            where T : BaseEventHandler, new()
        {
            RegisterEventHandler(eventId, new T());
        }

        public void RegisterEventHandler<T>(string eventId, T handler)
            where T : BaseEventHandler
        {
            if (!eventHandlers.ContainsKey(eventId))
            {
                eventHandlers.Add(eventId, new List<BaseEventHandler>());
            }
            eventHandlers[eventId].Add(handler);
        }

        public void RegisterWildcardEventHandler<T>()
            where T : BaseEventHandler, new()
        {
            RegisterWildcardEventHandler(new T());
        }

        public void RegisterWildcardEventHandler<T>(T handler)
            where T : BaseEventHandler
        {
            wildcardEventHandlers.Add(handler);
        }

        public IEnumerable<BaseEventHandler> GetEventHandlersOrDefault(string eventId)
        {
            var handlers = eventHandlers.ContainsKey(eventId) ?
                eventHandlers[eventId] :
                new List<BaseEventHandler>();

            if (handlers.Count + wildcardEventHandlers.Count == 0)
            {
                handlers.Add(new DefaultHandler());
            }
            else
            {
                handlers.AddRange(wildcardEventHandlers);
            }

            return handlers;
        }

    }
}
