using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitHubHook.Models
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum PullRequestReviewState
    {
        Commented,
        [EnumMember(Value = "changes_requested")]
        ChangesRequested,
        Approved
    }
}
