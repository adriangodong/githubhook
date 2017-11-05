using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("milestone")]
    public class MilestoneEvent : BaseEvent
    {
        public MilestoneEventAction Action { get; set; }
        public Milestone Milestone { get; set; }
    }
}
