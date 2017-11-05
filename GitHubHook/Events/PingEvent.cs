namespace GitHubHook.Models
{
    [GitHubEventType("ping")]
    public sealed class PingEvent : BaseEvent
    {
        public string Zen { get; set; }
        public int HookId { get; set; }
        public Hook Hook { get; set; }
    }
}
