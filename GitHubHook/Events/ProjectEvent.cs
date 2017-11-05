using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("project")]
    public class ProjectEvent : BaseEvent
    {
        public ProjectEventAction Action { get; set; }
        public Project Project { get; set; }
        public ProjectChanges Changes { get; set; }
    }
}
