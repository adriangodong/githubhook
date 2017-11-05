using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("push")]
    public class PushEvent : BaseEvent
    {
        public string Ref { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public bool Created { get; set; }
        public bool Deleted { get; set; }
        public bool Forced { get; set; }
        public string BaseRef { get; set; }
        public string Compare { get; set; }
        public Commit[] Commits { get; set; }
        public Commit HeadCommit { get; set; }
        public new PushRepository Repository { get; set; }
        public Pusher Pusher { get; set; }
    }
}
