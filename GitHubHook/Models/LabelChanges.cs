namespace GitHubHook.Models
{
    public class LabelChanges : SnakeCaseNamedObject
    {
        public Change<string> Name { get; set; }
        public Change<string> Color { get; set; }
    }
}
