namespace GitHubHook.Models
{
    public class PullRequestReviewChanges : SnakeCaseNamedObject
    {
        public Change<string> Body { get; set; }
    }
}
