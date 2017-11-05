namespace GitHubHook.Models
{
    [GitHubEventType("create")]
    public class CreateEvent : BaseEvent
    {
        public string Ref { get; set; }
        public RefType RefType { get; set; }
        public string MasterBranch { get; set; }
        public string Description { get; set; }
        public string PusherType { get; set; }
    }
}
