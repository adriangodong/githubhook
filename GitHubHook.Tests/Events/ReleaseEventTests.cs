using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class ReleaseEventTests : BaseEventTests
    {
        [TestMethod]
        public void Published_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("PublishedReleasePayload.json");

            // Act
            var releasePayload = JsonConvert.DeserializeObject<ReleaseEvent>(payload);

            // Assert
            Assert.IsNotNull(releasePayload);
            Console.WriteLine(JsonConvert.SerializeObject(releasePayload));
        }
    }
}
