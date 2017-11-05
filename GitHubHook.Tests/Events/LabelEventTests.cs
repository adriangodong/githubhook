using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class LabelEventTests : BaseEventTests
    {
        [TestMethod]
        public void Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedLabelPayload.json");

            // Act
            var labelPayload = JsonConvert.DeserializeObject<LabelEvent>(payload);

            // Assert
            Assert.IsNotNull(labelPayload);
            Console.WriteLine(JsonConvert.SerializeObject(labelPayload));
        }

        [TestMethod]
        public void Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedLabelPayload.json");

            // Act
            var labelPayload = JsonConvert.DeserializeObject<LabelEditedEvent>(payload);

            // Assert
            Assert.IsNotNull(labelPayload);
            Console.WriteLine(JsonConvert.SerializeObject(labelPayload));
        }
    }
}
