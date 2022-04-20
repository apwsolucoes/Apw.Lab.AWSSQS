using System;
using System.Threading;
using System.Threading.Tasks;

namespace Apw.Lab.AWSSQS.Producer
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var totalCount = 2;
            var message = "";

            for (int i = 1; i <= totalCount; i++)
            {
                message = $"Message content[{i}] {DateTime.Now}";

                try
                {
                    ApwLabAWSSQSProducer sqsMessageProducer = new ApwLabAWSSQSProducer();

                    await sqsMessageProducer.Send(message);

                    Console.WriteLine($"[{DateTime.Now}] Message {i} of {totalCount} sent success!");

                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: {ex.Message}");
                }                
            }
        }
    }
}
