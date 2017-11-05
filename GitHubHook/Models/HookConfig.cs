using GitHubHook.Helpers;

namespace GitHubHook.Models
{
    public sealed class HookConfig : SnakeCaseNamedObject
    {
        public string ContentType { get; set; }
        public string InsecureSsl { get; set; }
        public string Url { get; set; }
    }
}
