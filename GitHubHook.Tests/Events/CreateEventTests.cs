using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class CreateEventTests : BaseEventTests
    {
        [TestMethod]
        public void Branch_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("BranchCreatePayload.json");

            // Act
            var createPayload = JsonConvert.DeserializeObject<CreateEvent>(payload);

            // Assert
            Assert.IsNotNull(createPayload);
            Console.WriteLine(JsonConvert.SerializeObject(createPayload));
        }

        [TestMethod]
        public void Tag_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("TagCreatePayload.json");

            // Act
            var createPayload = JsonConvert.DeserializeObject<CreateEvent>(payload);

            // Assert
            Assert.IsNotNull(createPayload);
            Console.WriteLine(JsonConvert.SerializeObject(createPayload));
        }
    }
}
