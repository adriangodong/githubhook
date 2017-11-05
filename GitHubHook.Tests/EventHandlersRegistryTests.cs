using System;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.Events;
using GitHubHook.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubHook.Tests
{
    [TestClass]
    public class EventHandlersRegistryTests
    {

        private EventHandlersRegistry eventHandlers;

        [TestInitialize]
        public void Initialize()
        {
            eventHandlers = new EventHandlersRegistry();
        }

        [TestMethod]
        public void RegisterEventHandler_ShouldSucceed()
        {
            // Act
            eventHandlers.RegisterEventHandler<DefaultHandler>();

            // Assert
            Assert.AreEqual(1, eventHandlers.eventHandlers.Count);
        }

        [TestMethod]
        public void RegisterEventHandler_WithInstance_ShouldSucceed()
        {
            // Act
            eventHandlers.RegisterEventHandler(new DefaultHandler());

            // Assert
            Assert.AreEqual(1, eventHandlers.eventHandlers.Count);
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnOnlyDefaultHandler_IfEmpty()
        {
            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(new TestEvent()).ToList();

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(1, handlers.Count);
            Assert.IsTrue(handlers[0] is DefaultHandler);
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnRegisteredHandler_IfAdded()
        {
            // Arrange
            eventHandlers.RegisterEventHandler<TestHandler>();

            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(new TestEvent()).ToList();

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(1, handlers.Count);
            Assert.IsFalse(handlers[0] is DefaultHandler);
            Assert.IsTrue(handlers[0] is TestHandler);
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnMatchedHandlers()
        {
            // Arrange
            eventHandlers.RegisterEventHandler<TestHandler>();
            eventHandlers.RegisterEventHandler<TestEventHandler>();

            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(new TestEvent());

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(2, handlers.Count());
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldNotReturnMismatchedHandlers()
        {
            // Arrange
            eventHandlers.RegisterEventHandler<TestEventHandler>();

            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(new AnotherTestEvent()).ToList();

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(1, handlers.Count);
            Assert.IsTrue(handlers[0] is DefaultHandler);
        }

        private class TestEvent : BaseEvent
        {
        }

        private class AnotherTestEvent : BaseEvent
        {
        }

        private class TestHandler : BaseEventHandler
        {
            public override Task<string> HandleEvent(
                APIGatewayProxyRequest request,
                ILambdaContext context,
                string deliveryId,
                BaseEvent eventPayload)
            {
                throw new NotImplementedException();
            }
        }

        private class TestEventHandler : GitHubHook.Handlers.EventHandler<TestEvent>
        {
            public override Task<string> HandleEvent(
                APIGatewayProxyRequest request,
                ILambdaContext context,
                string deliveryId,
                TestEvent eventPayload)
            {
                throw new NotImplementedException();
            }
        }

    }
}
