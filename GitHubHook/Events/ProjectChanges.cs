using GitHubHook.Helpers;

namespace GitHubHook.Events
{
    public class ProjectChanges : SnakeCaseNamedObject
    {
        public Change<string> Name { get; set; }
        public Change<string> Body { get; set; }
    }
}
