using System;
using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    public class MilestoneChanges : SnakeCaseNamedObject
    {
        public Change<string> Description { get; set; }
        public Change<DateTime> DueOn { get; set; }
        public Change<string> Title { get; set; }
    }
}
