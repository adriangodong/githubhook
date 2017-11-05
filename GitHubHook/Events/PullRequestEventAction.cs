using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitHubHook.Events
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum PullRequestEventAction
    {
        Assigned,
        Unassigned,
        [EnumMember(Value = "review_requested")]
        ReviewRequested,
        [EnumMember(Value = "review_request_removed")]
        ReviewRequestRemoved,
        Labeled,
        Unlabeled,
        Opened,
        Edited,
        Closed,
        Reopened,
        Synchronize
    }
}
