using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("pull_request", "synchronize")]
    public class PullRequestSynchronizeEvent : PullRequestEvent
    {
        public string Before { get; set; }
        public string After { get; set; }
    }
}
