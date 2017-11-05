using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("issue_comment")]
    public class IssueCommentEvent : BaseActionEvent<IssueCommentEventAction>
    {
        public Issue Issue { get; set; }
        public IssueComment Comment { get; set; }
    }
}
