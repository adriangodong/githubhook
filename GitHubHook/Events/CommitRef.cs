using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    public class CommitRef : SnakeCaseNamedObject
    {
        public string Sha { get; set; }
        public string HtmlUrl { get; set; }
    }
}
