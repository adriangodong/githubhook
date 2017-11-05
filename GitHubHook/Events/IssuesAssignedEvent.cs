using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("issues", "assigned")]
    [GitHubEventType("issues", "unassigned")]
    public class IssuesAssignedEvent : IssuesEvent
    {
        public User Assignee { get; set; }
    }
}
