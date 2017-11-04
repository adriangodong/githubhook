namespace GitHubHook.Models
{
    [GitHubEventType("issue_comment")]
    public class IssueCommentEvent : BaseEvent
    {
        public IssueCommentEventAction Action { get; set; }
        public IssueCommentChanges Changes { get; set; }
        public Issue Issue { get; set; }
        public IssueComment Comment { get; set; }
    }
}
