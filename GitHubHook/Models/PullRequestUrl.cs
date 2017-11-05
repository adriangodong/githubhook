using GitHubHook.Helpers;

namespace GitHubHook.Models
{
    public class PullRequestUrl : SnakeCaseNamedObject
    {
        public string HtmlUrl { get; set; }
    }
}
