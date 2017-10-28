namespace GitHubHook.Models
{
    public class User : SnakeCaseNamedObject
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string AvatarUrl { get; set; }
        public string GravatarId { get; set; }
        public string HtmlUrl { get; set; }
        public string Type { get; set; }
        public bool SiteAdmin { get; set; }
    }
}
