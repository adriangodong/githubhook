using System;

namespace GitHubHook.Models
{
    public class Issue : SnakeCaseNamedObject
    {
        public string HtmlUrl { get; set; }
        public int Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public Label[] Labels { get; set; }
        public IssueState State { get; set; }
        public bool Locked { get; set; }
        public User Assignee { get; set; }
        public User[] Assignees { get; set; }
        public Milestone Milestone { get; set; }
        public int Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string AuthorAssociation { get; set; }
        public PullRequestUrl PullRequest { get; set; }
        public string Body { get; set; }
    }
}
