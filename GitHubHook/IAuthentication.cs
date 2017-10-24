using Amazon.Lambda.APIGatewayEvents;

namespace GitHubHook
{
    public interface IAuthentication
    {
        AuthenticationResult Authenticate(APIGatewayProxyRequest input);
    }
}
