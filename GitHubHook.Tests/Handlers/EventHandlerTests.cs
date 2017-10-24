using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.Handlers;
using GitHubHook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubHook.Tests.Handlers
{
    [TestClass]
    public class EventHandlerTests
    {

        [TestMethod]
        public async Task BaseEventHandler_HandleEvent_CallsGenericHandleEvent()
        {
            // Arrange
            BaseEventHandler handler = new TestHandler();

            // Act
            await handler.HandleEvent(null, null, null, new TestEvent1());

            // Assert
            Assert.IsTrue(((TestHandler)handler).HandleEventCalled);
        }

        [TestMethod]
        public async Task BaseEventHandler_HandleEvent_ThrowsException_MismatchedType()
        {
            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
            {
                // Arrange
                BaseEventHandler handler = new TestHandler();

                // Act
                await handler.HandleEvent(null, null, null, new TestEvent2());
            });
        }

        private class TestHandler : GitHubHook.Handlers.EventHandler<TestEvent1>
        {
            public override Task<string> HandleEvent(
                APIGatewayProxyRequest request,
                ILambdaContext context,
                string deliveryId,
                TestEvent1 eventPayload)
            {
                HandleEventCalled = true;
                return Task.FromResult<string>(null);
            }

            public bool HandleEventCalled { get; private set; }
        }

        private class TestEvent1 : BaseEvent
        {
        }

        private class TestEvent2 : BaseEvent
        {
        }

    }
}
