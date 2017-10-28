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

    }
}
