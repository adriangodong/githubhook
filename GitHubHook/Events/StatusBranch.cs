using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    public class StatusBranch : SnakeCaseNamedObject
    {
        public string Name { get; set; }
        public CommitRef Commit { get; set; }
    }
}
