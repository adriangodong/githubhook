using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("label")]
    public class LabelEvent : BaseActionEvent<LabelEventAction>
    {
        public Label Label { get; set; }
    }
}
