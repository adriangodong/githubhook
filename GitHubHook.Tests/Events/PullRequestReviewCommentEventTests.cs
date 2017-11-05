using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class PullRequestReviewCommentEventTests : BaseEventTests
    {
        [TestMethod]
        public void Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedPullRequestReviewCommentPayload.json");

            // Act
            var pullRequestReviewCommentPayload = JsonConvert.DeserializeObject<PullRequestReviewCommentEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestReviewCommentPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestReviewCommentPayload));
        }

        [TestMethod]
        public void Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedPullRequestReviewCommentPayload.json");

            // Act
            var pullRequestReviewCommentPayload = JsonConvert.DeserializeObject<PullRequestReviewCommentEditedEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestReviewCommentPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestReviewCommentPayload));
        }
    }
}
