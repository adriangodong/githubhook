using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class PushEventTests : BaseEventTests
    {
        [TestMethod]
        public void Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("PushPayload.json");

            // Act
            var pushPayload = JsonConvert.DeserializeObject<PushEvent>(payload);

            // Assert
            Assert.IsNotNull(pushPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pushPayload));
        }
    }
}
