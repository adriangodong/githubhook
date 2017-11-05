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
        public PullRequestChanges Changes { get; set; }
        public User Assignee { get; set; }
        public User RequestedReviewer { get; set; }
        public Label Label { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
    }
}
