using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Threading.Tasks;

namespace Apw.Lab.AWSSQS.Producer
{
    public class ApwLabAWSSQSProducer
    {
        public async Task Send(String message)
        {
            string accessKey = "";
            string secret = "";
            string queueUrl = "";
            bool useFifo = false;
            string messageGroupId = "";
            string awsregion = "";

            BasicAWSCredentials creds = new BasicAWSCredentials(accessKey, secret);

            RegionEndpoint region = RegionEndpoint.GetBySystemName(awsregion);

            SendMessageRequest sendMessageRequest = new SendMessageRequest(queueUrl, message);

            if (useFifo)
                sendMessageRequest.MessageGroupId = messageGroupId;

            try
            {
                var sqsClient = new AmazonSQSClient(creds, region);
                await sqsClient.SendMessageAsync(sendMessageRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }
        }
    }
}
