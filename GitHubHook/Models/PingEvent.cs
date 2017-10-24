namespace GitHubHook.Models
{
    [GitHubEventType("ping")]
    public sealed class PingEvent : BaseEvent
    {
        public string Zen { get; set; }
        public double HookId { get; set; }
    }
}
