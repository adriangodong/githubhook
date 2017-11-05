using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request_review")]
    public class PullRequestReviewEvent : BaseEvent
    {
        public PullRequestReviewEventAction Action { get; set; }
        public PullRequestReview Review { get; set; }
        public PullRequest PullRequest { get; set; }
        public PullRequestReviewChanges Changes { get; set; }
    }
}
