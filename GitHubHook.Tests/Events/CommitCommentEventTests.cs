using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class CommitCommentEventTests : BaseEventTests
    {
        [TestMethod]
        public void Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedCommitCommentPayload.json");

            // Act
            var commitCommentPayload = JsonConvert.DeserializeObject<CommitCommentEvent>(payload);

            // Assert
            Assert.IsNotNull(commitCommentPayload);
            Console.WriteLine(JsonConvert.SerializeObject(commitCommentPayload));
        }
    }
}
