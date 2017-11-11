using System;
using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    public class Release : SnakeCaseNamedObject
    {
        public string UploadUrl { get; set; }
        public string HtmlUrl { get; set; }
        public long Id { get; set; }
        public string TagName { get; set; }
        public string TargetCommitish { get; set; }
        public string Name { get; set; }
        public bool Draft { get; set; }
        public User Author { get; set; }
        public bool Prerelease { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string[] Assets { get; set; }
        public string Body { get; set; }
    }
}
