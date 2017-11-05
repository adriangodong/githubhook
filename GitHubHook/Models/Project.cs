using System;
using GitHubHook.Helpers;

namespace GitHubHook.Models
{
    public class Project : SnakeCaseNamedObject
    {
        public string HtmlUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
        public User Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
