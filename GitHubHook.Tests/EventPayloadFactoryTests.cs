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

        [TestMethod]
        public void RegisterEventType_ShouldRegisterAllGitHubEventTypeAttribute()
        {
            // Arrange
            var eventPayloadFactory = new EventPayloadFactory();

            // Act
            eventPayloadFactory.RegisterEventType(typeof(EditedTestActionEvent).GetTypeInfo());

            // Assert
            var editedEventType = eventPayloadFactory.GetRegisteredEventType("test", "edited");
            var updatedEventType = eventPayloadFactory.GetRegisteredEventType("test", "updated");
            Assert.AreEqual(typeof(EditedTestActionEvent), editedEventType);
            Assert.AreEqual(typeof(EditedTestActionEvent), updatedEventType);
        }

        [TestMethod]
        public void CreateEventPayload_KnownEventType_ShouldDeserializeToTargetType()
        {
            // Arrange
            var eventPayloadFactory = new EventPayloadFactory();

            // Act
            var eventPayload = eventPayloadFactory.CreateEventPayload("ping", "{}");

            // Assert
            Assert.IsTrue(eventPayload is PingEvent);
        }

        [TestMethod]
        public void CreateEventPayload_UnknownEventType_ShouldThrow()
        {
            // Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var eventPayloadFactory = new EventPayloadFactory();

                // Act
                eventPayloadFactory.CreateEventPayload("xxx", "{}");
            });
        }

        [TestMethod]
        public void CreateEventPayload_KnownActionEventType_WithoutSpecificAction_ShouldDeserializeToTargetType()
        {
            // Arrange
            var eventPayloadFactory = new EventPayloadFactory();
            eventPayloadFactory.RegisterEventType(typeof(TestActionEvent).GetTypeInfo());

            var payload = JsonConvert.SerializeObject(new TestActionEvent
            {
                Action = TestEnum.Created
            });

            // Act
            var eventPayload = eventPayloadFactory.CreateEventPayload("test", payload);

            // Assert
            Assert.IsTrue(eventPayload is TestActionEvent);
        }

        [TestMethod]
        public void CreateEventPayload_KnownActionEventType_WithSpecificAction_ShouldDeserializeToTargetType()
        {
            // Arrange
            var eventPayloadFactory = new EventPayloadFactory();
            eventPayloadFactory.RegisterEventType(typeof(TestActionEvent).GetTypeInfo());
            eventPayloadFactory.RegisterEventType(typeof(EditedTestActionEvent).GetTypeInfo());

            var payload = JsonConvert.SerializeObject(new TestActionEvent
            {
                Action = TestEnum.Edited
            });

            // Act
            var eventPayload = eventPayloadFactory.CreateEventPayload("test", payload);

            // Assert
            Assert.IsTrue(eventPayload is EditedTestActionEvent);
        }

        [TestMethod]
        public void CreateEventPayload_KnownActionEventType_MultiWord_ShouldDeserializeToTargetType()
        {
            // Arrange
            var eventPayloadFactory = new EventPayloadFactory();
            eventPayloadFactory.RegisterEventType(typeof(TestActionEvent).GetTypeInfo());

            var payload = JsonConvert.SerializeObject(new TestActionEvent
            {
                Action = TestEnum.MultiWord
            });

            // Act
            var eventPayload = eventPayloadFactory.CreateEventPayload("test", payload);

            // Assert
            Assert.IsTrue(eventPayload is TestActionEvent);
        }

        [JsonConverter(typeof(StringEnumConverter), true)]
        private enum TestEnum
        {
            Created,
            Edited,
            [EnumMember(Value = "multi_word")]
            MultiWord
        }

        [Helpers.GitHubEventType("test")]
        private class TestActionEvent : BaseActionEvent<TestEnum>
        {
        }

        [Helpers.GitHubEventType("test", "edited")]
        [Helpers.GitHubEventType("test", "updated")]
        private class EditedTestActionEvent : TestActionEvent
        {
        }

    }
}
