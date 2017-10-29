namespace GitHubHook.Models
{
    [GitHubEventType("milestone")]
    public class MilestoneEvent : BaseEvent
    {
        public MilestoneEventAction Action { get; set; }
        public Milestone Milestone { get; set; }
        public MilestoneChanges Changes { get; set; }
    }
}
