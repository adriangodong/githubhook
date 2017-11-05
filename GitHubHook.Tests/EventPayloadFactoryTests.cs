using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubHook.Tests
{
    [TestClass]
    public class EventPayloadFactoryTests
    {

        [TestMethod]
        public void CreateEventPayload_KnownEventType_ShouldDeserializeToTargetType()
        {
            // Arrange
            var eventRegistry = new EventPayloadFactory();

            // Act
            var eventPayload = eventRegistry.CreateEventPayload("ping", "{}");

            // Assert
            Assert.IsNotNull(eventPayload as PingEvent);
        }

        [TestMethod]
        public void CreateEventPayload_UnknownEventType_ShouldThrow()
        {
            // Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var eventRegistry = new EventPayloadFactory();

                // Act
                eventRegistry.CreateEventPayload("xxx", "{}");
            });
        }

    }
}
