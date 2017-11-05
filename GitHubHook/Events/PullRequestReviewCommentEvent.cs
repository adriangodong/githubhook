using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request_review_comment")]
    public class PullRequestReviewCommentEvent : BaseActionEvent<PullRequestReviewCommentEventAction>
    {
        public PullRequestReviewComment Comment { get; set; }
        public PullRequest PullRequest { get; set; }
    }
}
