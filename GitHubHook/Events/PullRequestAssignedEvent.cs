using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request", "assigned")]
    [GitHubEventType("pull_request", "unassigned")]
    public class PullRequestAssignedEvent : PullRequestEvent
    {
        public User Assignee { get; set; }
    }
}
