using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("milestone")]
    public class MilestoneEvent : BaseActionEvent<MilestoneEventAction>
    {
        public Milestone Milestone { get; set; }
    }
}
