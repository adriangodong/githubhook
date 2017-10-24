namespace GitHubHook
{
    public enum AuthenticationResult
    {
        Success,
        SignatureNotRequired,
        HasSignatureButMissingSecretToken,
        InvalidSignature,
        InvalidPayload,
        MismatchedSignature
    }
}
