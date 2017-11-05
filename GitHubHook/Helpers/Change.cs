namespace GitHubHook.Models
{
    public class Change<T> : SnakeCaseNamedObject
    {
        public T From { get; set; }
    }
}
