using System.Collections.Generic;
using GitHubHook.Events;
using GitHubHook.Handlers;

namespace GitHubHook
{
    public class EventHandlersRegistry : IEventHandlersRegistry
    {

        internal readonly List<BaseEventHandler> eventHandlers;

        public EventHandlersRegistry()
        {
            eventHandlers = new List<BaseEventHandler>();
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

            if (handlers.Count == 0)
            {
                handlers.Add(new DefaultHandler());
            }

            return handlers;
        }

    }
}
