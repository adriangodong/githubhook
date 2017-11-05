using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request_review_comment", "edited")]
    public class PullRequestReviewCommentEditedEvent : PullRequestReviewCommentEvent
    {
        public PullRequestReviewCommentChanges Changes { get; set; }
    }
}
