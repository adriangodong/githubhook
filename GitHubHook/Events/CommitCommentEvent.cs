namespace GitHubHook.Models
{
    [GitHubEventType("commit_comment")]
    public class CommitCommentEvent : BaseEvent
    {
        public CommitCommentEventAction Action { get; set; }
        public CommitComment Comment { get; set; }
    }
}
