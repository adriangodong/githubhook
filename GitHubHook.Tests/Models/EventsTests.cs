using GitHubHook.Tests.TestHelpers;
using GitHubHook.Tests.TestPayloads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using GitHubHook.Events;

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

        [TestMethod]
        public void MilestoneEvent_Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedMigrationPayload.json");

            // Act
            var milestonePayload = JsonConvert.DeserializeObject<MilestoneEvent>(payload);

            // Assert
            Assert.IsNotNull(milestonePayload);
            Console.WriteLine(JsonConvert.SerializeObject(milestonePayload));
        }

        [TestMethod]
        public void MilestoneEvent_Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedMilestonePayload.json");

            // Act
            var milestonePayload = JsonConvert.DeserializeObject<MilestoneEvent>(payload);

            // Assert
            Assert.IsNotNull(milestonePayload);
            Console.WriteLine(JsonConvert.SerializeObject(milestonePayload));
        }

        [TestMethod]
        public void LabelEvent_Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedLabelPayload.json");

            // Act
            var labelPayload = JsonConvert.DeserializeObject<LabelEvent>(payload);

            // Assert
            Assert.IsNotNull(labelPayload);
            Console.WriteLine(JsonConvert.SerializeObject(labelPayload));
        }

        [TestMethod]
        public void LabelEvent_Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedLabelPayload.json");

            // Act
            var labelPayload = JsonConvert.DeserializeObject<LabelEvent>(payload);

            // Assert
            Assert.IsNotNull(labelPayload);
            Console.WriteLine(JsonConvert.SerializeObject(labelPayload));
        }

        [TestMethod]
        public void ProjectEvent_Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedProjectPayload.json");

            // Act
            var projectPayload = JsonConvert.DeserializeObject<ProjectEvent>(payload);

            // Assert
            Assert.IsNotNull(projectPayload);
            Console.WriteLine(JsonConvert.SerializeObject(projectPayload));
        }

        [TestMethod]
        public void ProjectEvent_Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedProjectPayload.json");

            // Act
            var projectPayload = JsonConvert.DeserializeObject<ProjectEvent>(payload);

            // Assert
            Assert.IsNotNull(projectPayload);
            Console.WriteLine(JsonConvert.SerializeObject(projectPayload));
        }

        [TestMethod]
        public void IssuesEvent_Opened_Deserialize_ShouldSucceed()
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
        public void IssuesEvent_Edited_Deserialize_ShouldSucceed()
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
        public void IssuesEvent_Labeled_Deserialize_ShouldSucceed()
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
        public void IssuesEvent_Milestoned_Deserialize_ShouldSucceed()
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
        public void IssuesEvent_PullRequestMilestoned_Deserialize_ShouldSucceed()
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
        public void IssuesEvent_Unassigned_Deserialize_ShouldSucceed()
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
        public void IssuesEvent_Closed_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("ClosedIssuesPayload.json");

            // Act
            var issuesPayload = JsonConvert.DeserializeObject<IssuesEvent>(payload);

            // Assert
            Assert.IsNotNull(issuesPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issuesPayload));
        }

        [TestMethod]
        public void PullRequestEvent_Opened_Deserialize_ShouldSucceed()
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
        public void PullRequestEvent_Assigned_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("AssignedPullRequestPayload.json");

            // Act
            var pullRequestPayload = JsonConvert.DeserializeObject<PullRequestEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
        }

        [TestMethod]
        public void PullRequestEvent_ReviewRequested_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("ReviewRequestedPullRequestPayload.json");

            // Act
            var pullRequestPayload = JsonConvert.DeserializeObject<PullRequestEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
        }

        [TestMethod]
        public void PullRequestEvent_Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedPullRequestPayload.json");

            // Act
            var pullRequestPayload = JsonConvert.DeserializeObject<PullRequestEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
        }

        [TestMethod]
        public void PullRequestEvent_Synchronize_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("SynchronizePullRequestPayload.json");

            // Act
            var pullRequestPayload = JsonConvert.DeserializeObject<PullRequestEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestPayload));
        }

        [TestMethod]
        public void IssueCommentEvent_Created_Deserialize_ShouldSucceed()
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
        public void IssueCommentEvent_PullRequestCreated_Deserialize_ShouldSucceed()
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
        public void IssueCommentEvent_Edited_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("EditedIssueCommentPayload.json");

            // Act
            var issueCommentPayload = JsonConvert.DeserializeObject<IssueCommentEvent>(payload);

            // Assert
            Assert.IsNotNull(issueCommentPayload);
            Console.WriteLine(JsonConvert.SerializeObject(issueCommentPayload));
        }

        [TestMethod]
        public void PushEvent_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("PushPayload.json");

            // Act
            var pushPayload = JsonConvert.DeserializeObject<PushEvent>(payload);

            // Assert
            Assert.IsNotNull(pushPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pushPayload));
        }

        [TestMethod]
        public void CreateEvent_Branch_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("BranchCreatePayload.json");

            // Act
            var createPayload = JsonConvert.DeserializeObject<CreateEvent>(payload);

            // Assert
            Assert.IsNotNull(createPayload);
            Console.WriteLine(JsonConvert.SerializeObject(createPayload));
        }

        [TestMethod]
        public void CreateEvent_Tag_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("TagCreatePayload.json");

            // Act
            var createPayload = JsonConvert.DeserializeObject<CreateEvent>(payload);

            // Assert
            Assert.IsNotNull(createPayload);
            Console.WriteLine(JsonConvert.SerializeObject(createPayload));
        }

        [TestMethod]
        public void CommitCommentEvent_Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedCommitCommentPayload.json");

            // Act
            var commitCommentPayload = JsonConvert.DeserializeObject<CommitCommentEvent>(payload);

            // Assert
            Assert.IsNotNull(commitCommentPayload);
            Console.WriteLine(JsonConvert.SerializeObject(commitCommentPayload));
        }

        [TestMethod]
        public void DeleteEvent_Branch_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("BranchDeletePayload.json");

            // Act
            var deletePayload = JsonConvert.DeserializeObject<DeleteEvent>(payload);

            // Assert
            Assert.IsNotNull(deletePayload);
            Console.WriteLine(JsonConvert.SerializeObject(deletePayload));
        }

        [TestMethod]
        public void PullRequestReviewEvent_Submitted_Deserialize_ShouldSucceed()
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
        public void PullRequestReviewEvent_Dismissed_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("DismissedPullRequestReviewPayload.json");

            // Act
            var pullRequestReviewPayload = JsonConvert.DeserializeObject<PullRequestReviewEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestReviewPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestReviewPayload));
        }

        [TestMethod]
        public void PullRequestReviewCommentEvent_Created_Deserialize_ShouldSucceed()
        {
            // Arrange
            var payload = resourceManager.GetString("CreatedPullRequestReviewCommentPayload.json");

            // Act
            var pullRequestReviewCommentPayload = JsonConvert.DeserializeObject<PullRequestReviewCommentEvent>(payload);

            // Assert
            Assert.IsNotNull(pullRequestReviewCommentPayload);
            Console.WriteLine(JsonConvert.SerializeObject(pullRequestReviewCommentPayload));
        }

    }
}
