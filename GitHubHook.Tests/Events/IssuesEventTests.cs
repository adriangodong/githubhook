using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class IssuesEventTests : BaseEventTests
    {
        [TestMethod]
        public void Opened_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("OpenedIssuesPayload.json");

            // Act
            var issuesPayload = JsonConvert.DeserializeObject<IssuesEvent>(payload);

            // Assert
            Assert.IsNotNull(issuesPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issuesPayload));
        }

        [TestMethod]
        public void Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedIssuesPayload.json");

            // Act
            var issuesPayload = JsonConvert.DeserializeObject<IssuesEvent>(payload);

            // Assert
            Assert.IsNotNull(issuesPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issuesPayload));
        }

        [TestMethod]
        public void Labeled_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("LabeledIssuesPayload.json");

            // Act
            var issuesPayload = JsonConvert.DeserializeObject<IssuesEvent>(payload);

            // Assert
            Assert.IsNotNull(issuesPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issuesPayload));
        }

        [TestMethod]
        public void Milestoned_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("MilestonedIssuesPayload.json");

            // Act
            var issuesPayload = JsonConvert.DeserializeObject<IssuesEvent>(payload);

            // Assert
            Assert.IsNotNull(issuesPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issuesPayload));
        }

        [TestMethod]
        public void PullRequestMilestoned_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("PullRequestMilestonedIssuesPayload.json");

            // Act
            var issuesPayload = JsonConvert.DeserializeObject<IssuesEvent>(payload);

            // Assert
            Assert.IsNotNull(issuesPayload);
            Assert.IsNotNull(issuesPayload.Issue);
            Assert.IsNotNull(issuesPayload.Issue.PullRequest);
            Console.WriteLine(JsonConvert.SerializeObject(issuesPayload));
        }

        [TestMethod]
        public void Unassigned_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("UnassignedIssuesPayload.json");

            // Act
            var issuesPayload = JsonConvert.DeserializeObject<IssuesEvent>(payload);

            // Assert
            Assert.IsNotNull(issuesPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issuesPayload));
        }

        [TestMethod]
        public void Closed_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("ClosedIssuesPayload.json");

            // Act
            var issuesPayload = JsonConvert.DeserializeObject<IssuesEvent>(payload);

            // Assert
            Assert.IsNotNull(issuesPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issuesPayload));
        }
    }
}
