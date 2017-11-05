using System;

namespace GitHubHook.Models
{
    public class PullRequestReview : SnakeCaseNamedObject
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Body { get; set; }
        public string CommitId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public PullRequestReviewState State { get; set; }
        public string HtmlUrl { get; set; }
        public string PullRequestUrl { get; set; }
        public string AuthorAssociation { get; set; }
    }
}
