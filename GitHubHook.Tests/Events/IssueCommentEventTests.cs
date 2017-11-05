using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class IssueCommentEventTests : BaseEventTests
    {
        [TestMethod]
        public void Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedIssueCommentPayload.json");

            // Act
            var issueCommentPayload = JsonConvert.DeserializeObject<IssueCommentEvent>(payload);

            // Assert
            Assert.IsNotNull(issueCommentPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issueCommentPayload));
        }

        [TestMethod]
        public void PullRequestCreated_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("PullRequestCreatedIssueCommentPayload.json");

            // Act
            var issueCommentPayload = JsonConvert.DeserializeObject<IssueCommentEvent>(payload);

            // Assert
            Assert.IsNotNull(issueCommentPayload);
            Assert.IsNotNull(issueCommentPayload.Issue);
            Assert.IsNotNull(issueCommentPayload.Issue.PullRequest);
            Console.WriteLine(JsonConvert.SerializeObject(issueCommentPayload));
        }

        [TestMethod]
        public void Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedIssueCommentPayload.json");

            // Act
            var issueCommentPayload = JsonConvert.DeserializeObject<IssueCommentEditedEvent>(payload);

            // Assert
            Assert.IsNotNull(issueCommentPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issueCommentPayload));
        }
    }
}
