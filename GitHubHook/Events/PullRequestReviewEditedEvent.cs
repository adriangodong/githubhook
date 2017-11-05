using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request_review", "edited")]
    public class PullRequestReviewEditedEvent : PullRequestReviewEvent
    {
        public PullRequestReviewChanges Changes { get; set; }
    }
}
