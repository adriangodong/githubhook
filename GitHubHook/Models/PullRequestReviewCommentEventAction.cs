using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitHubHook.Models
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum PullRequestReviewCommentEventAction
    {
        Created,
        Edited,
        Deleted
    }
}
