using System;
using System.Collections.Generic;
using System.Reflection;
using GitHubHook.Models;
using Newtonsoft.Json;

namespace GitHubHook
{
    /// <summary>
    /// This class is responsible for maintaining a registry of known GitHub webhook event types.
    /// It also provide a factory method to deserialize JSON payload to C# POCO.
    /// Reference: https://developer.github.com/webhooks/#events
    /// </summary>
    public class EventPayloadFactory : IEventPayloadFactory
    {

        private readonly Dictionary<string, Type> eventTypesRegistry;

        public EventPayloadFactory()
        {
            eventTypesRegistry = new Dictionary<string, Type>();
            RegisterWellKnownEventTypes();
        }

        internal void RegisterWellKnownEventTypes()
        {
            foreach (var type in GetType().GetTypeInfo().Assembly.GetTypes())
            {
                var typeInfo = type.GetTypeInfo();

                if (!typeInfo.IsAbstract &&
                    typeInfo.IsClass &&
                    typeInfo.GetCustomAttribute<GitHubEventTypeAttribute>() != null)
                {
                    RegisterEventType(
                        typeInfo.GetCustomAttribute<GitHubEventTypeAttribute>().EventId,
                        type);
                }
            }
        }

        public void RegisterEventType(string eventId, Type eventType)
        {
            eventTypesRegistry.Add(eventId, eventType);
        }

        public BaseEvent CreateEventPayload(string eventId, string payload)
        {
            if (!eventTypesRegistry.ContainsKey(eventId))
            {
                throw new ArgumentException($"Unknown event type '{eventId}'");
            }

            var eventType = eventTypesRegistry[eventId];
            if (JsonConvert.DeserializeObject(payload, eventType) is BaseEvent eventPayload)
            {
                return eventPayload;
            }

            throw new ArgumentException($"Can't deserialize payload to type '{eventType}'");
        }

    }
}
