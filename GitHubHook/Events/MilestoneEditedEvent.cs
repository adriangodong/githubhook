using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("milestone", "edited")]
    public class MilestoneEditedEvent : MilestoneEvent
    {
        public MilestoneChanges Changes { get; set; }
    }
}
