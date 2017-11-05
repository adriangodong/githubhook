using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request_review")]
    public class PullRequestReviewEvent : BaseActionEvent<PullRequestReviewEventAction>
    {
        public PullRequestReview Review { get; set; }
        public PullRequest PullRequest { get; set; }
    }
}
