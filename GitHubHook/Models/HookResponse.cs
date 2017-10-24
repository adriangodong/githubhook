namespace GitHubHook.Models
{
    public sealed class HookResponse : SnakeCaseNamedObject
    {
        public double? Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
