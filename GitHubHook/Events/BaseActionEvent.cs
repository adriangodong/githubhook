using System;
using System.Reflection;
using Newtonsoft.Json;

namespace GitHubHook.Events
{
    public abstract class BaseActionEvent<T> : BaseEvent, IActionEvent where T : struct
    {
        static BaseActionEvent()
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("Generic type parameter T is not a System.Enum");
            }
        }

        public T Action { get; set; }

        public string GetActionValue()
        {
            // This isn't the best way but until we have a snake case converter, this will do.
            return JsonConvert.SerializeObject(Action).Trim('"');
        }
    }
}
