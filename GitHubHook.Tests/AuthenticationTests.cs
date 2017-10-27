using System;
using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using GitHubHook.Tests.TestHelpers;
using GitHubHook.Tests.TestPayloads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GitHubHook.Tests
{
    [TestClass]
    public class AuthenticationTests
    {

        private EnvironmentVariableScope envVarScope;
        private Mock<Authentication> mockAuthentication;
        private Authentication authentication;

        [TestInitialize]
        public void Initialize()
        {
            // Backup environment variable values
            envVarScope = new EnvironmentVariableScope(
                Authentication.RequireSignatureEnvironmentVariableName,
                Authentication.SecretTokenEnvironmentVariableName);
            mockAuthentication = new Mock<Authentication> { CallBase = true };
            authentication = mockAuthentication.Object;
        }

        [TestMethod]
        public void GenerateAndCompareSignature_TestSignature1()
        {
            // Arrange
            const string secretToken = "key";
            const string payload = "The quick brown fox jumps over the lazy dog";
            const string signature = "sha1=de7c9b85b8b78aa6bc8a7a36f70a90701c9db4d9";

            // Act
            var result = authentication.GenerateAndCompareSignature(secretToken, signature, payload);

            // Assert
            Assert.IsTrue(result);
        }

        [Ignore("Failing on AppVeyor.")]
        [TestMethod]
        public void GenerateAndCompareSignature_TestSignature2()
        {
            // Arrange
            var resmgr = new InternalResourceManager(typeof(TestPayloadsMarker));

            var payload = resmgr.GetString("PingPayload.json");
            var payloadSecurity = resmgr.GetString("PingPayloadSecurity.txt").Split(Environment.NewLine);
            var secretToken = payloadSecurity[0];
            var signature = payloadSecurity[1];

            // Act
            var result = authentication.GenerateAndCompareSignature(secretToken, signature, payload);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// + Signature is required by default
        /// + Signature header is missing
        /// 
        /// - Should return InvalidSignature
        /// </summary>
        [TestMethod]
        public void Authenticate_Test1()
        {
            // Arrange
            Environment.SetEnvironmentVariable(Authentication.RequireSignatureEnvironmentVariableName, null);
            var apiGatewayProxyRequest = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
            };

            // Act
            var authenticationResult = authentication.Authenticate(apiGatewayProxyRequest);

            // Assert
            Assert.AreEqual(AuthenticationResult.InvalidSignature, authenticationResult);
        }

        /// <summary>
        /// + Signature is set to required
        /// + Signature header is missing
        /// 
        /// - Should return InvalidSignature
        /// </summary>
        [TestMethod]
        public void Authenticate_Test2()
        {
            // Arrange
            Environment.SetEnvironmentVariable(Authentication.RequireSignatureEnvironmentVariableName, true.ToString());
            var apiGatewayProxyRequest = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
            };

            // Act
            var authenticationResult = authentication.Authenticate(apiGatewayProxyRequest);

            // Assert
            Assert.AreEqual(AuthenticationResult.InvalidSignature, authenticationResult);
        }

        /// <summary>
        /// + Signature is set to not required
        /// + Signature header is missing
        /// 
        /// - Should return SignatureNotRequired
        /// </summary>
        [TestMethod]
        public void Authenticate_Test3()
        {
            // Arrange
            Environment.SetEnvironmentVariable(Authentication.RequireSignatureEnvironmentVariableName, false.ToString());
            var apiGatewayProxyRequest = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
            };

            // Act
            var authenticationResult = authentication.Authenticate(apiGatewayProxyRequest);

            // Assert
            Assert.AreEqual(AuthenticationResult.SignatureNotRequired, authenticationResult);
        }

        /// <summary>
        /// + Signature is set to required
        /// + Signature header exists
        /// + Secret token is missing
        /// 
        /// - Should return HasSignatureButMissingSecretToken
        /// </summary>
        [TestMethod]
        public void Authenticate_Test4()
        {
            // Arrange
            Environment.SetEnvironmentVariable(Authentication.RequireSignatureEnvironmentVariableName, true.ToString());
            Environment.SetEnvironmentVariable(Authentication.SecretTokenEnvironmentVariableName, null);
            var apiGatewayProxyRequest = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
                {
                    { Authentication.XHubSignatureHeaderKey, Guid.NewGuid().ToString("N") }
                }
            };

            // Act
            var authenticationResult = authentication.Authenticate(apiGatewayProxyRequest);

            // Assert
            Assert.AreEqual(AuthenticationResult.HasSignatureButMissingSecretToken, authenticationResult);
        }

        /// <summary>
        /// + Signature is set to required
        /// + Signature header exists but random
        /// + Secret token exists
        /// 
        /// - Should return InvalidSignature
        /// </summary>
        [TestMethod]
        public void Authenticate_Test5()
        {
            // Arrange
            Environment.SetEnvironmentVariable(Authentication.RequireSignatureEnvironmentVariableName, true.ToString());
            Environment.SetEnvironmentVariable(Authentication.SecretTokenEnvironmentVariableName, Guid.NewGuid().ToString("N"));
            var apiGatewayProxyRequest = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
                {
                    { Authentication.XHubSignatureHeaderKey, Guid.NewGuid().ToString("N") }
                }
            };

            // Act
            var authenticationResult = authentication.Authenticate(apiGatewayProxyRequest);

            // Assert
            Assert.AreEqual(AuthenticationResult.InvalidSignature, authenticationResult);
        }

        /// <summary>
        /// + Signature is set to required
        /// + Signature header exists
        /// + Secret token exists
        /// + Payload is empty
        /// 
        /// - Should return InvalidPayload
        /// </summary>
        [TestMethod]
        public void Authenticate_Test6()
        {
            // Arrange
            Environment.SetEnvironmentVariable(Authentication.RequireSignatureEnvironmentVariableName, true.ToString());
            Environment.SetEnvironmentVariable(Authentication.SecretTokenEnvironmentVariableName, Guid.NewGuid().ToString("N"));
            var apiGatewayProxyRequest = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
                {
                    { Authentication.XHubSignatureHeaderKey, $"{Authentication.SignaturePrefix}{Guid.NewGuid():N}" }
                }
            };

            // Act
            var authenticationResult = authentication.Authenticate(apiGatewayProxyRequest);

            // Assert
            Assert.AreEqual(AuthenticationResult.InvalidPayload, authenticationResult);
        }

        /// <summary>
        /// + Signature is set to required
        /// + Signature header exists
        /// + Secret token exists
        /// + Payload exists
        /// + Signature mismatched
        /// 
        /// - Should return MismatchedSignature
        /// </summary>
        [TestMethod]
        public void Authenticate_Test7()
        {
            // Arrange
            Environment.SetEnvironmentVariable(Authentication.RequireSignatureEnvironmentVariableName, true.ToString());
            Environment.SetEnvironmentVariable(Authentication.SecretTokenEnvironmentVariableName, Guid.NewGuid().ToString("N"));
            var apiGatewayProxyRequest = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
                {
                    { Authentication.XHubSignatureHeaderKey, $"{Authentication.SignaturePrefix}{Guid.NewGuid():N}" }
                },
                Body = Guid.NewGuid().ToString("N")
            };
            mockAuthentication
                .Setup(mock => mock.GenerateAndCompareSignature(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(false);

            // Act
            var authenticationResult = authentication.Authenticate(apiGatewayProxyRequest);

            // Assert
            Assert.AreEqual(AuthenticationResult.MismatchedSignature, authenticationResult);
        }

        /// <summary>
        /// + Signature is set to required
        /// + Signature header exists
        /// + Secret token exists
        /// + Payload exists
        /// + Signature matched
        /// 
        /// - Should return InvalidPayload
        /// </summary>
        [TestMethod]
        public void Authenticate_Test8()
        {
            // Arrange
            Environment.SetEnvironmentVariable(Authentication.RequireSignatureEnvironmentVariableName, true.ToString());
            Environment.SetEnvironmentVariable(Authentication.SecretTokenEnvironmentVariableName, Guid.NewGuid().ToString("N"));
            var apiGatewayProxyRequest = new APIGatewayProxyRequest
            {
                Headers = new Dictionary<string, string>()
                {
                    { Authentication.XHubSignatureHeaderKey, $"{Authentication.SignaturePrefix}{Guid.NewGuid():N}" }
                },
                Body = Guid.NewGuid().ToString("N")
            };
            mockAuthentication
                .Setup(mock => mock.GenerateAndCompareSignature(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(true);

            // Act
            var authenticationResult = authentication.Authenticate(apiGatewayProxyRequest);

            // Assert
            Assert.AreEqual(AuthenticationResult.Success, authenticationResult);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Restore environment variable values
            envVarScope.Dispose();
        }
    }
}
