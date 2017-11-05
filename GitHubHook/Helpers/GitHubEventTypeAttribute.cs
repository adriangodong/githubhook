using System;

namespace GitHubHook.Helpers
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal class GitHubEventTypeAttribute : Attribute
    {
        public string EventId { get; set; }

        public GitHubEventTypeAttribute(string eventId)
        {
            EventId = eventId;
        }
    }
}
