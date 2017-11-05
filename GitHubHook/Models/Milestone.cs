using System;
using GitHubHook.Helpers;

namespace GitHubHook.Models
{
    public class Milestone : SnakeCaseNamedObject
    {
        public string HtmlUrl { get; set; }
        public int Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }
        public int OpenIssues { get; set; }
        public int ClosedIssues { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DueOn { get; set; }
        public DateTime? ClosedAt { get; set; }
    }
}
