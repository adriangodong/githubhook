using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    public class LabelChanges : SnakeCaseNamedObject
    {
        public Change<string> Name { get; set; }
        public Change<string> Color { get; set; }
    }
}
