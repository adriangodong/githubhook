using System;
using GitHubHook.Events;

namespace GitHubHook
{
    public interface IEventPayloadFactory
    {
        BaseEvent CreateEventPayload(string eventId, string payload);
        void RegisterEventType(string eventId, Type eventType);
    }
}
