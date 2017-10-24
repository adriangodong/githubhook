using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GitHubHook.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class SnakeCaseNamedObject
    {
    }
}
