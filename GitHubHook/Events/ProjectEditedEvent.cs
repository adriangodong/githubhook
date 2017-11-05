using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("project", "edited")]
    public class ProjectEditedEvent : ProjectEvent
    {
        public ProjectChanges Changes { get; set; }
    }
}
