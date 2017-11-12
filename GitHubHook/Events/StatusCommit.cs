using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    public class StatusCommit : SnakeCaseNamedObject
    {
        public string Sha { get; set; }
        // TODO: public object Commit { get; set; }
        public string HtmlUrl { get; set; }
        public User Author { get; set; }
        public User Committer { get; set; }
        public CommitRef[] Parents { get; set; }
    }
}
