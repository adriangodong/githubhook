namespace GitHubHook.Models
{
    public class IssueChanges : SnakeCaseNamedObject
    {
        public Change<string> Title { get; set; }
        public Change<string> Body { get; set; }
    }
}
