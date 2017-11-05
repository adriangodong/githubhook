using System;
using System.Reflection;
using System.Runtime.Serialization;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitHubHook.Tests
{
    [TestClass]
    public class EventPayloadFactoryTests
    {

        private EventPayloadFactory eventPayloadFactory;

        [TestInitialize]
        public void Initialize()
        {
            eventPayloadFactory = new EventPayloadFactory();
        }

        [TestMethod]
        public void RegisterEventType_ShouldRegisterEventIdOnlyIfActionNotProvided()
        {
            // Act
            eventPayloadFactory.RegisterEventType(typeof(TestActionEvent).GetTypeInfo());

            // Assert
            var eventType = eventPayloadFactory.GetRegisteredEventType("test", null);
            var unknownEventType = eventPayloadFactory.GetRegisteredEventType(
                "test",
                Guid.NewGuid().ToString("N"));
            Assert.AreEqual(typeof(TestActionEvent), eventType);
            Assert.IsNull(unknownEventType);
        }

        [TestMethod]
        public void RegisterEventType_ShouldNotRegisterEventIdOnlyIfActionIsProvided()
        {
            // Act
            eventPayloadFactory.RegisterEventType(typeof(EditedTestActionEvent).GetTypeInfo());

            // Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                eventPayloadFactory.GetRegisteredEventType("test", null);
            });
        }

        [TestMethod]
        public void RegisterEventType_ShouldRegisterAllInstancesOfGitHubEventTypeAttribute()
        {
            // Act
            eventPayloadFactory.RegisterEventType(typeof(EditedTestActionEvent).GetTypeInfo());

            // Assert
            var editedEventType = eventPayloadFactory.GetRegisteredEventType("test", "edited");
            var updatedEventType = eventPayloadFactory.GetRegisteredEventType("test", "updated");
            Assert.AreEqual(typeof(EditedTestActionEvent), editedEventType);
            Assert.AreEqual(typeof(EditedTestActionEvent), updatedEventType);
        }

        [TestMethod]
        public void RegisterEventType_DuplicateKey_ShouldThrow()
        {
            // Arrange
            eventPayloadFactory.RegisterEventType(typeof(TestActionEvent).GetTypeInfo());

            // Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Act
                eventPayloadFactory.RegisterEventType(typeof(TestActionEvent).GetTypeInfo());
            });
        }

        [TestMethod]
        public void CreateEventPayload_KnownEventId_ShouldDeserializeToTargetType()
        {
            // Act
            var eventPayload = eventPayloadFactory.CreateEventPayload("ping", "{}");

            // Assert
            Assert.IsTrue(eventPayload is PingEvent);
        }

        [TestMethod]
        public void CreateEventPayload_UnknownEventId_ShouldThrow()
        {
            // Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Act
                eventPayloadFactory.CreateEventPayload("xxx", "{}");
            });
        }

        [TestMethod]
        public void CreateEventPayload_KnownEventId_NoAction_ShouldDeserializeToEventType()
        {
            // Arrange
            eventPayloadFactory.RegisterEventType(typeof(TestActionEvent).GetTypeInfo());

            var payload = JsonConvert.SerializeObject(new TestActionEvent
            {
                Action = TestAction.Created
            });

            // Act
            var eventPayload = eventPayloadFactory.CreateEventPayload("test", payload);

            // Assert
            Assert.IsTrue(eventPayload is TestActionEvent);
        }

        [TestMethod]
        public void CreateEventPayload_KnownEventId_WithAction_ShouldDeserializeToActionEventType()
        {
            // Arrange
            eventPayloadFactory.RegisterEventType(typeof(TestActionEvent).GetTypeInfo());
            eventPayloadFactory.RegisterEventType(typeof(EditedTestActionEvent).GetTypeInfo());

            var payload = JsonConvert.SerializeObject(new TestActionEvent
            {
                Action = TestAction.Edited
            });

            // Act
            var eventPayload = eventPayloadFactory.CreateEventPayload("test", payload);

            // Assert
            Assert.IsTrue(eventPayload is EditedTestActionEvent);
        }

        [TestMethod]
        public void CreateEventPayload_KnownEventId_WithMultiWordAction_ShouldDeserializeToTargetType()
        {
            // Arrange
            eventPayloadFactory.RegisterEventType(typeof(TestActionEvent).GetTypeInfo());

            var payload = JsonConvert.SerializeObject(new TestActionEvent
            {
                Action = TestAction.MultiWord
            });

            // Act
            var eventPayload = eventPayloadFactory.CreateEventPayload("test", payload);

            // Assert
            Assert.IsTrue(eventPayload is TestActionEvent);
        }

        [DataTestMethod]
        [DataRow("ping", null)]
        [DataRow(null, "{}")]
        public void CreateEventPayload_BadInput_ShouldThrow(string eventId, string payload)
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                // Act
                eventPayloadFactory.CreateEventPayload(eventId, payload);
            });
        }

        [TestMethod]
        public void CreateEventPayload_BadPayload_ShouldThrow()
        {
            // Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Act
                eventPayloadFactory.CreateEventPayload("ping", string.Empty);
            });
        }

        [JsonConverter(typeof(StringEnumConverter), true)]
        private enum TestAction
        {
            Created,
            Edited,
            [EnumMember(Value = "multi_word")]
            MultiWord
        }

        [Helpers.GitHubEventType("test")]
        private class TestActionEvent : BaseActionEvent<TestAction>
        {
        }

        [Helpers.GitHubEventType("test", "edited")]
        [Helpers.GitHubEventType("test", "updated")]
        private class EditedTestActionEvent : TestActionEvent
        {
        }

    }
}
