using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    public class IssueCommentChanges : SnakeCaseNamedObject
    {
        public Change<string> Body { get; set; }
    }
}
