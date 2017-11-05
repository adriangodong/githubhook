using System;
using System.Collections.Generic;
using GitHubHook.Helpers;

namespace GitHubHook
{
    internal class DeliveryResult : SnakeCaseNamedObject
    {
        public DeliveryResult()
        {
            EventHandlerResults = new List<string>();
        }

        public void SetEventPayloadType(Type type)
        {
            EventPayloadType = $"Payload: {type.Name}";
        }

        public string EventPayloadType { get; private set; }
        public List<string> EventHandlerResults { get; }
    }
}
