using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("issues", Action = "labeled")]
    [GitHubEventType("issues", Action = "unlabeled")]
    public class IssuesLabeledEvent : IssuesEvent
    {
        public Label Label { get; set; }
    }
}
