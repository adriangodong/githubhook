using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request")]
    public class PullRequestEvent : BaseEvent
    {
        public PullRequestEventAction Action { get; set; }
        public int Number { get; set; }
        public PullRequest PullRequest { get; set; }
    }
}
