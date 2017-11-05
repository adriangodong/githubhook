namespace GitHubHook.Models
{
    [GitHubEventType("delete")]
    public class DeleteEvent : BaseEvent
    {
        public string Ref { get; set; }
        public RefType RefType { get; set; }
        public string PusherType { get; set; }
    }
}
