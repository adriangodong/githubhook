using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitHubHook.Models
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum PullRequestEventAction
    {
        Assigned,
        Unassigned,
        ReviewRequested,
        ReviewRequestRemoved,
        Labeled,
        Unlabeled,
        Opened,
        Edited,
        Closed,
        Reopened
    }
}
