using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    public class IssueChanges : SnakeCaseNamedObject
    {
        public Change<string> Title { get; set; }
        public Change<string> Body { get; set; }
    }
}
