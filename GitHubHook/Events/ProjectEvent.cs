using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("project")]
    public class ProjectEvent : BaseActionEvent<ProjectEventAction>
    {
        public Project Project { get; set; }
    }
}
