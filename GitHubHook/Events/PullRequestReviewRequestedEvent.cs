using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request", "review_requested")]
    [GitHubEventType("pull_request", "review_request_removed")]
    public class PullRequestReviewRequestedEvent : PullRequestEvent
    {
        public User RequestedReviewer { get; set; }
    }
}
