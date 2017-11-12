using System;
using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    [GitHubEventType("status")]
    public class StatusEvent : BaseEvent
    {
        public long Id { get; set; }
        public string Sha { get; set; }
        public string Name { get; set; }
        public string TargetUrl { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public StatusEventState State { get; set; }
        public StatusCommit Commit { get; set; }
        public StatusBranch[] Branches { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
