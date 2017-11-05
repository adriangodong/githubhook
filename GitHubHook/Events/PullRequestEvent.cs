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

    [GitHubEventType("pull_request", "edited")]
    public class EditedPullRequestEvent : PullRequestEvent
    {
        public PullRequestChanges Changes { get; set; }
    }

    [GitHubEventType("pull_request", "assigned")]
    [GitHubEventType("pull_request", "unassigned")]
    public class AssignedPullRequestEvent : PullRequestEvent
    {
        public User Assignee { get; set; }
    }

    [GitHubEventType("pull_request", "labeled")]
    [GitHubEventType("pull_request", "unlabeled")]
    public class LabeledPullRequestEvent : PullRequestEvent
    {
        public Label Label { get; set; }
    }

    [GitHubEventType("pull_request", "review_requested")]
    [GitHubEventType("pull_request", "review_request_removed")]
    public class ReviewRequestedPullRequestEvent : PullRequestEvent
    {
        public User RequestedReviewer { get; set; }
    }

    [GitHubEventType("pull_request", "synchronize")]
    public class SynchronizePullRequestEvent : PullRequestEvent
    {
        public string Before { get; set; }
        public string After { get; set; }
    }
}
