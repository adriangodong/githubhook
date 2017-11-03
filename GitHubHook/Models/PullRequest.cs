using System;

namespace GitHubHook.Models
{
    public class PullRequest : SnakeCaseNamedObject
    {
        public int Id { get; set; }
        public string HtmlUrl { get; set; }
        public string DiffUrl { get; set; }
        public string PatchUrl { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
        public bool Locked { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public DateTime? MergedAt { get; set; }
        public string MergeCommitSha { get; set; }
        public User Assignee { get; set; }
        public User[] Assignees { get; set; }
        public User[] RequestedReviewers { get; set; }
        public Milestone Milestone { get; set; }
        public BranchRef Head { get; set; }
        public BranchRef Base { get; set; }
        // Link Relations
        //"_links": {
        //	"html": {
        //		"href": "https://github.com/adriangodong/ghh-test/pull/2"
        //	},
        //},
        public string AuthorAssociation { get; set; }
        public bool Merged { get; set; }
        public bool? Mergeable { get; set; }
        public bool? Rebaseable { get; set; }
        public string MergeableState { get; set; }
        public User MergedBy { get; set; }
        public int Comments { get; set; }
        public int ReviewComments { get; set; }
        public bool MaintainerCanModify { get; set; }
        public int Commits { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }
        public int ChangedFiles { get; set; }
    }
}
