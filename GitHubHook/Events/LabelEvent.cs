namespace GitHubHook.Models
{
    [GitHubEventType("label")]
    public class LabelEvent : BaseEvent
    {
        public LabelEventAction Action { get; set; }
        public Label Label { get; set; }
        public LabelChanges Changes { get; set; }
    }
}
