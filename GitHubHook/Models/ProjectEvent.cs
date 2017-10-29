namespace GitHubHook.Models
{
    [GitHubEventType("project")]
    public class ProjectEvent : BaseEvent
    {
        public ProjectEventAction Action { get; set; }
        public Project Project { get; set; }
        public ProjectChanges Changes { get; set; }
    }
}
