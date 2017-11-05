using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("commit_comment")]
    public class CommitCommentEvent : BaseActionEvent<CommitCommentEventAction>
    {
        public CommitComment Comment { get; set; }
    }
}
