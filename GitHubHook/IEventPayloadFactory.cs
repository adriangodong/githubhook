using GitHubHook.Events;

namespace GitHubHook
{
    public interface IEventPayloadFactory
    {
        BaseEvent CreateEventPayload(string eventId, string payload);
        void RegisterEventType<T>(string eventId, string action = null);
    }
}
