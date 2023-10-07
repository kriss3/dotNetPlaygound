using Azure.Messaging.ServiceBus;
using System.Threading.Tasks;
using static System.Console;

namespace PlayingWithAsbReceiver;

internal class Program
{
    const string ASB_CONN_STRING = "Endpoint=sb://kws-servicebus-test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=BQeTTMtmpwBExkO3Bc4czG9yuyEt3wW76514patMHwc=";
    const string QUEUE_NAME = "testqueue";

    static void Main(string[] args)
    {
        WriteLine("Hello, Azure Service Bus. Attempt to receive Messages from Queue!");
        ReceiveMessages().Wait();
    }

    private static async Task ReceiveMessages()
    {
        // the client that owns the connection and can be used to create senders and receivers
        ServiceBusClient client;

        // the processor that reads and processes messages from the queue
        ServiceBusProcessor processor;

        // TODO: Replace the <NAMESPACE-CONNECTION-STRING> and <QUEUE-NAME> placeholders
        var clientOptions = new ServiceBusClientOptions()
        {
            TransportType = ServiceBusTransportType.AmqpWebSockets
        };
        client = new ServiceBusClient(ASB_CONN_STRING, clientOptions);

        // create a processor that we can use to process the messages
        // TODO: Replace the <QUEUE-NAME> placeholder
        processor = client.CreateProcessor(QUEUE_NAME, new ServiceBusProcessorOptions());

        try
        {
            // add handler to process messages
            processor.ProcessMessageAsync += MessageHandler;

            // add handler to process any errors
            processor.ProcessErrorAsync += ErrorHandler;

            // start processing 
            await processor.StartProcessingAsync();

            WriteLine("Wait for a minute and then press any key to end the processing");
            ReadKey();

            // stop processing 
            WriteLine("\nStopping the receiver...");
            await processor.StopProcessingAsync();
            WriteLine("Stopped receiving messages");
        }
        finally
        {
            // Calling DisposeAsync on client types is required to ensure that network
            // resources and other unmanaged objects are properly cleaned up.
            await processor.DisposeAsync();
            await client.DisposeAsync();
        }

    }

    // handle received messages
    private static async Task MessageHandler(ProcessMessageEventArgs args)
    {
        string body = args.Message.Body.ToString();
        WriteLine($"Received: {body}");

        // complete the message. message is deleted from the queue. 
        await args.CompleteMessageAsync(args.Message);
    }

    // handle any errors when receiving messages
    private static Task ErrorHandler(ProcessErrorEventArgs args)
    {
        WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }
}
