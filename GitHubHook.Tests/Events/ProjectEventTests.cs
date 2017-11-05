using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class ProjectEventTests : BaseEventTests
    {
        [TestMethod]
        public void Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedProjectPayload.json");

            // Act
            var projectPayload = JsonConvert.DeserializeObject<ProjectEvent>(payload);

            // Assert
            Assert.IsNotNull(projectPayload);
            Console.WriteLine(JsonConvert.SerializeObject(projectPayload));
        }

        [TestMethod]
        public void Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedProjectPayload.json");

            // Act
            var projectPayload = JsonConvert.DeserializeObject<ProjectEditedEvent>(payload);

            // Assert
            Assert.IsNotNull(projectPayload);
            Console.WriteLine(JsonConvert.SerializeObject(projectPayload));
        }
    }
}
