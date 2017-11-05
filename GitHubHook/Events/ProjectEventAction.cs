using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitHubHook.Events
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ProjectEventAction
    {
        Created,
        Edited,
        Closed,
        Reopened,
        Deleted
    }
}
