using System;

namespace GitHubHook.Models
{
    public class CommitComment : SnakeCaseNamedObject
    {
        public string HtmlUrl { get; set; }
        public int Id { get; set; }
        public User User { get; set; }
        public int? Position { get; set; }
        public int? Line { get; set; }
        public string Path { get; set; }
        public string CommitId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AuthorAssociation { get; set; }
        public string Body { get; set; }
    }
}
