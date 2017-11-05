using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("issue_comment", "edited")]
    public class IssueCommentEditedEvent : IssueCommentEvent
    {
        public IssueCommentChanges Changes { get; set; }
    }
}
