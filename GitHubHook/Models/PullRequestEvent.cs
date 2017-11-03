namespace GitHubHook.Models
{
    [GitHubEventType("pull_request")]
    public class PullRequestEvent : BaseEvent
    {
        public PullRequestEventAction Action { get; set; }
        public int Number { get; set; }
        public PullRequestChanges Changes { get; set; }
        public PullRequest PullRequest { get; set; }
    }
}
