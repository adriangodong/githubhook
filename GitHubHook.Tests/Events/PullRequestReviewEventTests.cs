using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class PullRequestReviewEventTests : BaseEventTests
    {
        [TestMethod]
        public void Submitted_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("SubmittedPullRequestReviewPayload.json");

            // Act
            var pullRequestReviewPayload = JsonConvert.DeserializeObject<PullRequestReviewEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestReviewPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestReviewPayload));
        }

        [TestMethod]
        public void Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedPullRequestReviewPayload.json");

            // Act
            var pullRequestReviewPayload = JsonConvert.DeserializeObject<PullRequestReviewEditedEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestReviewPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestReviewPayload));
        }

        [TestMethod]
        public void Dismissed_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("DismissedPullRequestReviewPayload.json");

            // Act
            var pullRequestReviewPayload = JsonConvert.DeserializeObject<PullRequestReviewEditedEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestReviewPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestReviewPayload));
        }
    }
}
