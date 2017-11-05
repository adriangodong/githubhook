using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request", "edited")]
    public class PullRequestEditedEvent : PullRequestEvent
    {
        public PullRequestChanges Changes { get; set; }
    }
}
