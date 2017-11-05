using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("issue_comment")]
    public class IssueCommentEvent : BaseEvent
    {
        public IssueCommentEventAction Action { get; set; }
        public Issue Issue { get; set; }
        public IssueComment Comment { get; set; }
    }
}
