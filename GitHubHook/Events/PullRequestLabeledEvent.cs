using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request", "labeled")]
    [GitHubEventType("pull_request", "unlabeled")]
    public class PullRequestLabeledEvent : PullRequestEvent
    {
        public Label Label { get; set; }
    }
}
