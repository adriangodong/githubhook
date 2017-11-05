namespace GitHubHook.Models
{
    public class ProjectChanges : SnakeCaseNamedObject
    {
        public Change<string> Name { get; set; }
        public Change<string> Body { get; set; }
    }
}
