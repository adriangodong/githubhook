﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitHubHook.Models
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum IssuesEventAction
    {
        Assigned,
        Unassigned,
        Labeled,
        Unlabeled,
        Opened,
        Edited,
        Milestoned,
        Demilestoned,
        Closed,
        Reopened
    }
}
