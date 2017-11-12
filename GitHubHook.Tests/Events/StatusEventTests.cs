using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class StatusEventTests : BaseEventTests
    {
        [TestMethod]
        public void Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("StatusPayload.json");

            // Act
            var statusPayload = JsonConvert.DeserializeObject<StatusEvent>(payload);

            // Assert
            Assert.IsNotNull(statusPayload);
            Console.WriteLine(JsonConvert.SerializeObject(statusPayload));
        }
    }
}
