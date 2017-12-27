using GitHubHook.Helpers;
using GitHubHook.Models;

namespace GitHubHook.Events
{
    public abstract class BaseEvent : SnakeCaseNamedObject
    {
        public Repository Repository { get; set; }
        public User Sender { get; set; }
        public Installation Installation { get; set; }
    }
}
