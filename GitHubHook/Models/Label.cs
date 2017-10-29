namespace GitHubHook.Models
{
    public class Label : SnakeCaseNamedObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool Default { get; set; }
    }
}
