namespace GitHubHook.Models
{
    public class PullRequestReviewCommentChanges : SnakeCaseNamedObject
    {
        public Change<string> Body { get; set; }
    }
}
