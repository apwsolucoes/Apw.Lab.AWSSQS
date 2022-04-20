using System.Threading.Tasks;

namespace Apw.Lab.AWSSQS.Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SQSMessageConsumer sqsConsumer = new SQSMessageConsumer();

            await sqsConsumer.Listen();

        }
    }
}