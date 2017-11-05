using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("label", "edited")]
    public class LabelEditedEvent : LabelEvent
    {
        public LabelChanges Changes { get; set; }
    }
}
