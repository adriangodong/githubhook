using GitHubHook.Models;
using GitHubHook.Tests.TestHelpers;
using GitHubHook.Tests.TestPayloads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace GitHubHook.Tests.Models
{
    [TestClass]
    public class EventsTests
    {

        private static InternalResourceManager resourceManager;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            resourceManager = new InternalResourceManager(typeof(TestPayloadsMarker));
        }

        [TestMethod]
        public void PingEvent_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("PingPayload.json");

            // Act
            var pingPayload = JsonConvert.DeserializeObject<PingEvent>(payload);

            // Assert
            Assert.IsNotNull(pingPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pingPayload));
        }

        [TestMethod]
        public void MilestoneEvent_Create_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreateMigrationPayload.json");

            // Act
            var milestonePayload = JsonConvert.DeserializeObject<MilestoneEvent>(payload);

            // Assert
            Assert.IsNotNull(milestonePayload);
            Console.WriteLine(JsonConvert.SerializeObject(milestonePayload));
        }

        [TestMethod]
        public void MilestoneEvent_Update_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("UpdateMigrationPayload.json");

            // Act
            var milestonePayload = JsonConvert.DeserializeObject<MilestoneEvent>(payload);

            // Assert
            Assert.IsNotNull(milestonePayload);
            Console.WriteLine(JsonConvert.SerializeObject(milestonePayload));
        }

        [TestMethod]
        public void LabelEvent_Create_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreateLabelPayload.json");

            // Act
            var labelPayload = JsonConvert.DeserializeObject<LabelEvent>(payload);

            // Assert
            Assert.IsNotNull(labelPayload);
            Console.WriteLine(JsonConvert.SerializeObject(labelPayload));
        }

        [TestMethod]
        public void LabelEvent_Update_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("UpdateLabelPayload.json");

            // Act
            var labelPayload = JsonConvert.DeserializeObject<LabelEvent>(payload);

            // Assert
            Assert.IsNotNull(labelPayload);
            Console.WriteLine(JsonConvert.SerializeObject(labelPayload));
        }

        [TestMethod]
        public void ProjectEvent_Create_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreateProjectPayload.json");

            // Act
            var projectPayload = JsonConvert.DeserializeObject<ProjectEvent>(payload);

            // Assert
            Assert.IsNotNull(projectPayload);
            Console.WriteLine(JsonConvert.SerializeObject(projectPayload));
        }

        [TestMethod]
        public void ProjectEvent_Update_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("UpdateProjectPayload.json");

            // Act
            var projectPayload = JsonConvert.DeserializeObject<ProjectEvent>(payload);

            // Assert
            Assert.IsNotNull(projectPayload);
            Console.WriteLine(JsonConvert.SerializeObject(projectPayload));
        }

    }
}
