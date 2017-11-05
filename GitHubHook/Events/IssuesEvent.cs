using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("issues")]
    public class IssuesEvent : BaseActionEvent<IssuesEventAction>
    {
        public Issue Issue { get; set; }
    }
}
