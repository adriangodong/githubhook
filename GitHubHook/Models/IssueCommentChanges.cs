namespace GitHubHook.Models
{
    public class IssueCommentChanges : SnakeCaseNamedObject
    {
        public Change<string> Body { get; set; }
    }
}
