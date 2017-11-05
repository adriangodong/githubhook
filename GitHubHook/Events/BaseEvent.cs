namespace GitHubHook.Models
{
    public abstract class BaseEvent : SnakeCaseNamedObject
    {
        public Repository Repository { get; set; }
        public User Sender { get; set; }
    }
}
