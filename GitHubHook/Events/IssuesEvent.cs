﻿using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    [GitHubEventType("issues")]
    public class IssuesEvent : BaseEvent
    {
        public IssuesEventAction Action { get; set; }
        public Issue Issue { get; set; }
        public IssueChanges Changes { get; set; }
        public User Assignee { get; set; }
        public Label Label { get; set; }
    }
}