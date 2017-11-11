using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("release")]
    public class ReleaseEvent : BaseActionEvent<ReleaseEventAction>
    {
        public Release Release { get; set; }
    }
}
