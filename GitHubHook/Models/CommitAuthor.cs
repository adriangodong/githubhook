namespace GitHubHook.Models
{
    public class CommitAuthor : SnakeCaseNamedObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
