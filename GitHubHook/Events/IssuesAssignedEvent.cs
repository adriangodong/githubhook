using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("issues", Action = "assigned")]
    [GitHubEventType("issues", Action = "unassigned")]
    public class IssuesAssignedEvent : IssuesEvent
    {
        public User Assignee { get; set; }
    }
}