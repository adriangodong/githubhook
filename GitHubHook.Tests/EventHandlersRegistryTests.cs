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
        public void RegisterWildcardEventHandler_ShouldSucceed()
        {
            // Act
            eventHandlers.RegisterWildcardEventHandler<DefaultHandler>();

            // Assert
            Assert.AreEqual(1, eventHandlers.wildcardEventHandlers.Count);
        }

        [TestMethod]
        public void RegisterWildcardEventHandler_WithInstance_ShouldSucceed()
        {
            // Act
            eventHandlers.RegisterWildcardEventHandler(new DefaultHandler());

            // Assert
            Assert.AreEqual(1, eventHandlers.wildcardEventHandlers.Count);
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnOnlyDefaultHandler_IfEmpty()
        {
            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(new TestEvent());

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(1, handlers.Count());
            Assert.IsTrue(handlers.First() is DefaultHandler);
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnRegisteredHandler_IfAdded()
        {
            // Arrange
            eventHandlers.RegisterEventHandler<TestHandler>();

            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(new TestEvent());

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(1, handlers.Count());
            Assert.IsFalse(handlers.First() is DefaultHandler);
            Assert.IsTrue(handlers.First() is TestHandler);
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnRegisteredWildcardHandler_IfAdded()
        {
            // Arrange
            eventHandlers.RegisterWildcardEventHandler<TestHandler>();

            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(new TestEvent());

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(1, handlers.Count());
            Assert.IsFalse(handlers.First() is DefaultHandler);
            Assert.IsTrue(handlers.First() is TestHandler);
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnRegisteredAndWildcardHandler_IfAdded()
        {
            // Arrange
            eventHandlers.RegisterEventHandler<TestHandler>();
            eventHandlers.RegisterWildcardEventHandler<TestHandler>();

            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(new TestEvent());

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(2, handlers.Count());
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnAllValidHandlers()
        {
            // Arrange
            eventHandlers.RegisterEventHandler<TestHandler>();
            eventHandlers.RegisterEventHandler<DerivedTestHandler>();

            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(new TestEvent());

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(2, handlers.Count());
        }

        private class TestEvent : BaseEvent
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

        private class DerivedTestHandler : GitHubHook.Handlers.EventHandler<TestEvent>
        {
            public override Task<string> HandleEvent(APIGatewayProxyRequest request, ILambdaContext context, string deliveryId,
                TestEvent eventPayload)
            {
                throw new NotImplementedException();
            }
        }

    }
}
