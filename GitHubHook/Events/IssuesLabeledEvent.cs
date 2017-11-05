using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("issues", "labeled")]
    [GitHubEventType("issues", "unlabeled")]
    public class IssuesLabeledEvent : IssuesEvent
    {
        public Label Label { get; set; }
    }
}
