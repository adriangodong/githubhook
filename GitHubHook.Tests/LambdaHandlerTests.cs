using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.Events;
using GitHubHook.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GitHubHook.Tests
{
    [TestClass]
    public class LambdaHandlerTests
    {

        private Mock<IAuthentication> mockAuthentication;
        private Mock<IEventHandlersRegistry> mockEventHandlers;
        private Mock<IEventPayloadFactory> mockEventPayloadFactory;
        private Mock<ILambdaContext> mockLambdaContext;
        private Mock<ILambdaLogger> mockLambdaLogger;

        private LambdaHandler lambdaHandler;

        [TestInitialize]
        public void Initialize()
        {
            mockAuthentication = new Mock<IAuthentication>();
            mockEventHandlers = new Mock<IEventHandlersRegistry>();
            mockEventPayloadFactory = new Mock<IEventPayloadFactory>();
            mockLambdaContext = new Mock<ILambdaContext>();
            mockLambdaLogger = new Mock<ILambdaLogger>();

            mockLambdaContext
                .Setup(mock => mock.Logger)
                .Returns(mockLambdaLogger.Object);

            lambdaHandler = new LambdaHandler(
                mockAuthentication.Object,
                mockEventHandlers.Object,
                mockEventPayloadFactory.Object);
        }

        [DataTestMethod]
        [DataRow(AuthenticationResult.HasSignatureButMissingSecretToken, 500)]
        [DataRow(AuthenticationResult.InvalidSignature, 400)]
        [DataRow(AuthenticationResult.InvalidPayload, 400)]
        [DataRow(AuthenticationResult.MismatchedSignature, 401)]
        public async Task Handle_Test1(AuthenticationResult authenticationResult, int statusCode)
        {
            // Arrange
            mockAuthentication
                .Setup(mock => mock.Authenticate(It.IsAny<APIGatewayProxyRequest>()))
                .Returns(authenticationResult);

            // Act
            var result = await lambdaHandler.Handle(null, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(statusCode, result.StatusCode);
        }

        /// <summary>
        /// + Authenticate returns AuthenticationResult.Success or AuthenticationResult.SignatureNotRequired
        /// + Delivery ID is missing
        /// 
        /// - Returns 400
        /// </summary>
        [DataTestMethod]
        [DataRow(AuthenticationResult.Success)]
        [DataRow(AuthenticationResult.SignatureNotRequired)]
        public async Task Handle_Test2(AuthenticationResult authenticationResult)
        {
            // Arrange
            mockAuthentication
                .Setup(mock => mock.Authenticate(It.IsAny<APIGatewayProxyRequest>()))
                .Returns(authenticationResult);

            var request = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
            };

            // Act
            var result = await lambdaHandler.Handle(request, mockLambdaContext.Object);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        /// <summary>
        /// + Authenticate returns AuthenticationResult.Success or AuthenticationResult.SignatureNotRequired
        /// + Delivery ID exists
        /// + Event ID is missing
        /// 
        /// - Returns 400
        /// </summary>
        [DataTestMethod]
        [DataRow(AuthenticationResult.Success)]
        [DataRow(AuthenticationResult.SignatureNotRequired)]
        public async Task Handle_Test3(AuthenticationResult authenticationResult)
        {
            // Arrange
            mockAuthentication
                .Setup(mock => mock.Authenticate(It.IsAny<APIGatewayProxyRequest>()))
                .Returns(authenticationResult);

            var request = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
                {
                    { LambdaHandler.XGitHubDeliveryHeaderKey, Guid.NewGuid().ToString("N") }
                }
            };

            // Act
            var result = await lambdaHandler.Handle(request, mockLambdaContext.Object);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [DataTestMethod]
        [DataRow(AuthenticationResult.Success)]
        [DataRow(AuthenticationResult.SignatureNotRequired)]
        public async Task Handle_AllValid_ShouldReturnOkResponse(AuthenticationResult authenticationResult)
        {
            // Arrange
            var body = Guid.NewGuid().ToString("N");

            mockAuthentication
                .Setup(mock => mock.Authenticate(It.IsAny<APIGatewayProxyRequest>()))
                .Returns(authenticationResult);

            mockEventHandlers
                .Setup(mock => mock.GetEventHandlersOrDefault(It.IsAny<BaseEvent>()))
                .Returns(new List<BaseEventHandler>
                {
                    new DefaultHandler()
                });

            mockEventPayloadFactory
                .Setup(mock => mock.CreateEventPayload(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new Mock<BaseEvent>().Object);

            var request = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>
                {
                    { LambdaHandler.XGitHubDeliveryHeaderKey, Guid.NewGuid().ToString("N") },
                    { LambdaHandler.XGitHubEventHeaderKey, Guid.NewGuid().ToString("N") }
                },
                Body = body
            };

            // Act
            var response = await lambdaHandler.Handle(request, mockLambdaContext.Object);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
        }

    }
}
