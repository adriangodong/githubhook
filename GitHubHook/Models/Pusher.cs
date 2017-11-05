using GitHubHook.Helpers;

namespace GitHubHook.Models
{
    public class Pusher : SnakeCaseNamedObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
