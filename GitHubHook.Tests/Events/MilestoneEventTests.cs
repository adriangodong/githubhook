using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class MilestoneEventTests : BaseEventTests
    {
        [TestMethod]
        public void Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedMigrationPayload.json");

            // Act
            var milestonePayload = JsonConvert.DeserializeObject<MilestoneEvent>(payload);

            // Assert
            Assert.IsNotNull(milestonePayload);
            Console.WriteLine(JsonConvert.SerializeObject(milestonePayload));
        }

        [TestMethod]
        public void Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedMilestonePayload.json");

            // Act
            var milestonePayload = JsonConvert.DeserializeObject<MilestoneEditedEvent>(payload);

            // Assert
            Assert.IsNotNull(milestonePayload);
            Console.WriteLine(JsonConvert.SerializeObject(milestonePayload));
        }
    }
}
