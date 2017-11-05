using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("ping")]
    public sealed class PingEvent : BaseEvent
    {
        public string Zen { get; set; }
        public int HookId { get; set; }
        public Hook Hook { get; set; }
    }
}
