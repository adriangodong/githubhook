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

        internal void RegisterEventType(TypeInfo typeInfo)
        {
            foreach (var eventRegistryKey in GetEventRegistryKeys(typeInfo))
            {
                eventTypesRegistry.Add(eventRegistryKey, typeInfo.AsType());
            }
        }

        internal Type GetRegisteredEventType(string eventId, string action)
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

            return eventTypesRegistry[eventRegistryKey];
        }

        public BaseEvent CreateEventPayload(string eventId, string payload)
        {
            return CreateEventPayloadInternal(eventId, null, payload);
        }

        internal BaseEvent CreateEventPayloadInternal(string eventId, string action, string payload)
        {
            if (string.IsNullOrWhiteSpace(eventId))
            {
                throw new ArgumentNullException(nameof(eventId));
            }

            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            var eventType = GetRegisteredEventType(eventId, action);

            if (eventType == null)
            {
                return null;
            }

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

        internal static IEnumerable<string> GetEventRegistryKeys(TypeInfo typeInfo)
        {
            var eventRegistryKeys = new List<string>();

            foreach (var gitHubEventTypeAttribute in typeInfo.GetCustomAttributes<GitHubEventTypeAttribute>())
            {
                eventRegistryKeys.Add(
                    GetEventRegistryKey(
                        gitHubEventTypeAttribute.EventId,
                        gitHubEventTypeAttribute.Action));
            }

            return eventRegistryKeys;
        }

        internal static string GetEventRegistryKey(string eventId, string action)
        {
            return action == null ? eventId : $"{eventId}:{action}";
        }

    }
}
