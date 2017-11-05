using System;
using GitHubHook.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubHook.Tests.Events
{
    [TestClass]
    public class BaseActionEventTests
    {

        [TestMethod]
        public void ctor_WhenTIsNotEnum_ShouldThrowException()
        {
            // Assert
            Assert.ThrowsException<TypeInitializationException>(() =>
            {
                // Act
                new TestActionEvent();
            });
        }

        private class TestActionEvent : BaseActionEvent<int>
        {
        }

    }
}
