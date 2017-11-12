using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitHubHook.Events
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum StatusEventState
    {
        Pending,
        Success,
        Failure,
        Error
    }
}
