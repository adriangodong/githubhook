using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("label")]
    public class LabelEvent : BaseEvent
    {
        public LabelEventAction Action { get; set; }
        public Label Label { get; set; }
        public LabelChanges Changes { get; set; }
    }
}
