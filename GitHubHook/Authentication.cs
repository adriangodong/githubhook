using System;
using System.Security.Cryptography;
using System.Text;
using Amazon.Lambda.APIGatewayEvents;

namespace GitHubHook
{
    // https://developer.github.com/webhooks/securing/
    public class Authentication : IAuthentication
    {

        internal const string XHubSignatureHeaderKey = "X-Hub-Signature";
        internal const string RequireSignatureEnvironmentVariableName = "REQUIRE_SIGNATURE";
        internal const string SecretTokenEnvironmentVariableName = "SECRET_TOKEN";
        internal const string SignaturePrefix = "sha1=";

        public AuthenticationResult Authenticate(APIGatewayProxyRequest input)
        {
            if (!input.Headers.TryGetValue(XHubSignatureHeaderKey, out var signature) ||
                string.IsNullOrWhiteSpace(signature))
            {
                if (!bool.TryParse(
                    Environment.GetEnvironmentVariable(RequireSignatureEnvironmentVariableName),
                    out var requireSignature))
                {
                    // Require signature by default
                    requireSignature = true;
                }

                return requireSignature ?
                    AuthenticationResult.InvalidSignature :
                    AuthenticationResult.SignatureNotRequired;
            }

            var secretToken = Environment.GetEnvironmentVariable(SecretTokenEnvironmentVariableName);
            if (string.IsNullOrWhiteSpace(secretToken))
            {
                return AuthenticationResult.HasSignatureButMissingSecretToken;
            }

            if (!signature.StartsWith(SignaturePrefix))
            {
                return AuthenticationResult.InvalidSignature;
            }

            if (string.IsNullOrWhiteSpace(input.Body))
            {
                return AuthenticationResult.InvalidPayload;
            }

            if (!GenerateAndCompareSignature(secretToken, signature, input.Body))
            {
                return AuthenticationResult.MismatchedSignature;
            }

            return AuthenticationResult.Success;
        }

        internal virtual bool GenerateAndCompareSignature(string secretToken, string signature, string payload)
        {
            var secretTokenBytes = Encoding.ASCII.GetBytes(secretToken);
            var payloadBytes = Encoding.UTF8.GetBytes(payload);
            var expectedSignatureBytes = new HMACSHA1(secretTokenBytes).ComputeHash(payloadBytes);
            var expectedSignatureHex = Amazon.Util.AWSSDKUtils.BytesToHexString(expectedSignatureBytes);

            return string.Equals(
                signature.Substring(SignaturePrefix.Length),
                expectedSignatureHex,
                StringComparison.OrdinalIgnoreCase);
        }

    }
}
