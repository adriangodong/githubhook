using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("issues", "edited")]
    public class IssuesEditedEvent : IssuesEvent
    {
        public IssueChanges Changes { get; set; }
    }
}
