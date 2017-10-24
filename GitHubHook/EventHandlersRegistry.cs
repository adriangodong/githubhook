using System.Collections.Generic;
using GitHubHook.Handlers;

namespace GitHubHook
{
    public class EventHandlersRegistry : IEventHandlersRegistry
    {
        internal readonly Dictionary<string, List<BaseEventHandler>> eventHandlers;

        public EventHandlersRegistry()
        {
            eventHandlers = new Dictionary<string, List<BaseEventHandler>>();
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

        public IEnumerable<BaseEventHandler> GetEventHandlersOrDefault(string eventId)
        {
            var handlers = eventHandlers.ContainsKey(eventId) ?
                eventHandlers[eventId] :
                new List<BaseEventHandler>();

            if (handlers.Count == 0)
            {
                handlers.Add(new DefaultHandler());
            }

            return handlers;
        }

    }
}
