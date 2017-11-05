using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GitHubHook.Helpers
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class SnakeCaseNamedObject
    {
    }
}
