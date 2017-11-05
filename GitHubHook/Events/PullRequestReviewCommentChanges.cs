using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    public class PullRequestReviewCommentChanges : SnakeCaseNamedObject
    {
        public Change<string> Body { get; set; }
    }
}
