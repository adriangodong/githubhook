using System;

namespace GitHubHook.Helpers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    internal class GitHubEventTypeAttribute : Attribute
    {
        public string EventId { get; }
        public string Action { get; }

        public GitHubEventTypeAttribute(string eventId) : this(eventId, null)
        {
        }

        public GitHubEventTypeAttribute(string eventId, string action)
        {
            EventId = eventId;
            Action = action;
        }
    }
}
