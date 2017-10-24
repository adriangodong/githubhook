using System;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.Handlers;
using GitHubHook.Models;
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
        public void Ctor_ShouldNotFail()
        {
            // Assert
            new EventHandlersRegistry();
        }

        [TestMethod]
        public void RegisterEventHandler_ShouldSucceed()
        {
            // Act
            eventHandlers.RegisterEventHandler<DefaultHandler>("ping");

            // Assert
            Assert.AreEqual(1, eventHandlers.eventHandlers.Count);
        }

        [TestMethod]
        public void RegisterEventHandler_WithInstance_ShouldSucceed()
        {
            // Act
            eventHandlers.RegisterEventHandler("ping", new DefaultHandler());

            // Assert
            Assert.AreEqual(1, eventHandlers.eventHandlers.Count);
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnOnlyDefaultHandler_IfEmpty()
        {
            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(Guid.NewGuid().ToString("N"));

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(1, handlers.Count());
            Assert.IsTrue(handlers.First() is DefaultHandler);
        }

        [TestMethod]
        public void GetEventHandlersOrDefault_ShouldReturnRegisteredHandler_IfAdded()
        {
            // Arrange
            var eventId = Guid.NewGuid().ToString("N");
            eventHandlers.RegisterEventHandler<TestHandler>(eventId);

            // Act
            var handlers = eventHandlers.GetEventHandlersOrDefault(eventId);

            // Assert
            Assert.IsNotNull(handlers);
            Assert.AreEqual(1, handlers.Count());
            Assert.IsFalse(handlers.First() is DefaultHandler);
            Assert.IsTrue(handlers.First() is TestHandler);
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

    }
}
