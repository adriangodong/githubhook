using System;
using System.Collections.Generic;
using System.Reflection;
using GitHubHook.Events;
using GitHubHook.Helpers;
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
                    typeInfo.IsClass)
                {
                    RegisterEventType(typeInfo);
                }
            }
        }

        internal int RegisterEventType(TypeInfo typeInfo)
        {
            var typesRegistered = 0;

            foreach (var gitHubEventTypeAttribute in typeInfo.GetCustomAttributes<GitHubEventTypeAttribute>())
            {
                eventTypesRegistry.Add(
                    GetEventRegistryKey(
                        gitHubEventTypeAttribute.EventId,
                        gitHubEventTypeAttribute.Action),
                    typeInfo.AsType());
                typesRegistered++;
            }

            return typesRegistered;
        }

        public void RegisterEventType<T>(string eventId, string action)
        {
            eventTypesRegistry.Add(GetEventRegistryKey(eventId, action), typeof(T));
        }

        public BaseEvent CreateEventPayload(string eventId, string payload)
        {
            return CreateEventPayloadInternal(eventId, null, payload);
        }

        internal BaseEvent CreateEventPayloadInternal(string eventId, string action, string payload)
        {
            var eventRegistryKey = GetEventRegistryKey(eventId, action);

            if (!eventTypesRegistry.ContainsKey(eventRegistryKey))
            {
                if (action == null)
                {
                    throw new ArgumentException($"Unknown event type '{eventRegistryKey}'");
                }

                return null;
            }

            var eventType = eventTypesRegistry[eventRegistryKey];

            if (JsonConvert.DeserializeObject(payload, eventType) is BaseEvent eventPayload)
            {
                if (action == null && eventPayload is IActionEvent actionEventPayload)
                {
                    return CreateEventPayloadInternal(eventId, actionEventPayload.GetActionValue(), payload) ?? eventPayload;
                }

                return eventPayload;
            }

            throw new ArgumentException($"Can't deserialize payload to type '{eventType}'");
        }

        private string GetEventRegistryKey(string eventId, string action)
        {
            return action == null ? eventId : $"{eventId}:{action}";
        }

    }
}
