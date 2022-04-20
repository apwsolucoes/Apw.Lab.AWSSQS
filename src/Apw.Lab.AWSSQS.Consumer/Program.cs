using System.Threading.Tasks;

namespace Apw.Lab.AWSSQS.Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ApwLabAWSSQSConsumer sqsConsumer = new ApwLabAWSSQSConsumer();
            await sqsConsumer.Listen();
        }
    }
}