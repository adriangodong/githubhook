using System;

namespace GitHubHook.Models
{
    public sealed class Hook : SnakeCaseNamedObject
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string[] Events { get; set; }
        public HookConfig Config { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public HookResponse LastResponse { get; set; }
    }
}
