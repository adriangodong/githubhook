using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("issues", Action = "edited")]
    public class IssuesEditedEvent : IssuesEvent
    {
        public IssueChanges Changes { get; set; }
    }
}
