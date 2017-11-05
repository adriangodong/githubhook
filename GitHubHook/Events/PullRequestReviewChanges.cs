using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    public class PullRequestReviewChanges : SnakeCaseNamedObject
    {
        public Change<string> Body { get; set; }
    }
}
