namespace GitHubHook.Helpers
{
    public class Change<T> : SnakeCaseNamedObject
    {
        public T From { get; set; }
    }
}
