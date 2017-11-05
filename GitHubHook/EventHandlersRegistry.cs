using System.Collections.Generic;
using GitHubHook.Events;
using GitHubHook.Handlers;

namespace GitHubHook
{
    public class EventHandlersRegistry : IEventHandlersRegistry
    {

        internal readonly List<BaseEventHandler> eventHandlers;
        internal readonly List<BaseEventHandler> wildcardEventHandlers;

        public EventHandlersRegistry()
        {
            eventHandlers = new List<BaseEventHandler>();
            wildcardEventHandlers = new List<BaseEventHandler>();
        }

        public void RegisterEventHandler<T>()
            where T : BaseEventHandler, new()
        {
            RegisterEventHandler(new T());
        }

        public void RegisterEventHandler<T>(T handler)
            where T : BaseEventHandler
        {
            eventHandlers.Add(handler);
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

        public IEnumerable<BaseEventHandler> GetEventHandlersOrDefault(BaseEvent eventPayload)
        {
            var type = eventPayload.GetType();
            var handlers = new List<BaseEventHandler>();

            foreach (var eventHandler in eventHandlers)
            {
                if (eventHandler.CanHandleEvent(type))
                {
                    handlers.Add(eventHandler);
                }
                
            }

            handlers.AddRange(wildcardEventHandlers);

            if (handlers.Count == 0)
            {
                handlers.Add(new DefaultHandler());
            }

            return handlers;
        }

    }
}
