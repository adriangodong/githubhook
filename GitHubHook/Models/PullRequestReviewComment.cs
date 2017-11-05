using System;

namespace GitHubHook.Models
{
    public class PullRequestReviewComment : SnakeCaseNamedObject
    {
        public int PullRequestReviewId { get; set; }
        public int Id { get; set; }
        public string DiffHunk { get; set; }
        public string Path { get; set; }
        public int Position { get; set; }
        public int OriginalPosition { get; set; }
        public string CommitId { get; set; }
        public string OriginalCommitId { get; set; }
        public User User { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string HtmlUrl { get; set; }
        public string PullRequestUrl { get; set; }
        public string AuthorAssociation { get; set; }
    }
}
