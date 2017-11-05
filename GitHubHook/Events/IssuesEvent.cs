using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("issues")]
    public class IssuesEvent : BaseActionEvent<IssuesEventAction>
    {
        public Issue Issue { get; set; }
    }

    [GitHubEventType("issues", Action = "edited")]
    public class EditedIssuesEvent : IssuesEvent
    {
        public IssueChanges Changes { get; set; }
    }

    [GitHubEventType("issues", Action = "assigned")]
    [GitHubEventType("issues", Action = "unassigned")]
    public class AssignedIssuesEvent : IssuesEvent
    {
        public User Assignee { get; set; }
    }

    [GitHubEventType("issues", Action = "labeled")]
    [GitHubEventType("issues", Action = "unlabeled")]
    public class LabeledIssuesEvent : IssuesEvent
    {
        public Label Label { get; set; }
    }
}
