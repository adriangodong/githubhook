using System;

namespace GitHubHook.Models
{
    public class Commit : SnakeCaseNamedObject
    {
        public string Id { get; set; }
        public string TreeId { get; set; }
        public bool Distinct { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string Url { get; set; }
        public CommitAuthor Author { get; set; }
        public CommitAuthor Committer { get; set; }
        public string[] Added { get; set; }
        public string[] Removed { get; set; }
        public string[] Modified { get; set; }
    }
}
