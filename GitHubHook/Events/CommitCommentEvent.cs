using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("commit_comment")]
    public class CommitCommentEvent : BaseEvent
    {
        public CommitCommentEventAction Action { get; set; }
        public CommitComment Comment { get; set; }
    }
}
