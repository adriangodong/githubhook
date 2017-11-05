using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class PullRequestEventTests : BaseEventTests
    {
        [TestMethod]
        public void Opened_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("OpenedPullRequestPayload.json");

            // Act
            var pullRequestPayload = JsonConvert.DeserializeObject<PullRequestEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
        }

        [TestMethod]
        public void Assigned_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("AssignedPullRequestPayload.json");

            // Act
            var pullRequestPayload = JsonConvert.DeserializeObject<AssignedPullRequestEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
        }

        [TestMethod]
        public void Unlabeled_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("UnlabeledPullRequestPayload.json");

        // Act
        var pullRequestPayload = JsonConvert.DeserializeObject<LabeledPullRequestEvent>(payload);

        // Assert
        Assert.IsNotNull(pullRequestPayload);
        Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
    }

        [TestMethod]
        public void ReviewRequested_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("ReviewRequestedPullRequestPayload.json");

            // Act
            var pullRequestPayload = JsonConvert.DeserializeObject<ReviewRequestedPullRequestEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
        }

        [TestMethod]
        public void Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedPullRequestPayload.json");

            // Act
            var pullRequestPayload = JsonConvert.DeserializeObject<EditedPullRequestEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
        }

        [TestMethod]
        public void Synchronize_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("SynchronizePullRequestPayload.json");

            // Act
            var pullRequestPayload = JsonConvert.DeserializeObject<SynchronizePullRequestEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
        }
    }
}
