using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class DeleteEventTests : BaseEventTests
    {
        [TestMethod]
        public void Branch_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("BranchDeletePayload.json");

            // Act
            var deletePayload = JsonConvert.DeserializeObject<DeleteEvent>(payload);

            // Assert
            Assert.IsNotNull(deletePayload);
            Console.WriteLine(JsonConvert.SerializeObject(deletePayload));
        }
    }
}
