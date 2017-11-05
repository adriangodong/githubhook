﻿using System;
using GitHubHook.Helpers;

namespace GitHubHook.Models
{
    public class IssueComment : SnakeCaseNamedObject
    {
        public string HtmlUrl { get; set; }
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AuthorAssociation { get; set; }
        public string Body { get; set; }
    }
}
