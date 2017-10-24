using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using GitHubHook.Models;

namespace GitHubHook.S3Dump.Handlers
{
    internal class AnyToS3Handler : GitHubHook.Handlers.BaseEventHandler
    {
        private const string PingToS3BucketNameEnvironmentVariableName = "PINGTOS3_BUCKET_NAME";
        private readonly string bucketName;

        public AnyToS3Handler()
        {
            bucketName = Environment.GetEnvironmentVariable(PingToS3BucketNameEnvironmentVariableName);
        }

        public override async Task<string> HandleEvent(
            APIGatewayProxyRequest request,
            ILambdaContext context,
            string deliveryId,
            BaseEvent eventPayload)
        {
            var client = new Amazon.S3.AmazonS3Client();
            var putObjectRequest = new Amazon.S3.Model.PutObjectRequest
            {
                BucketName = bucketName,
                Key = deliveryId,
                ContentBody = request.Body
            };

            await client.PutObjectAsync(putObjectRequest);

            return $"Event payload uploaded to {bucketName}/{deliveryId}";
        }
    }
}
