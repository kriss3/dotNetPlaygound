using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using static System.Console;

namespace PlayingWithAsb;

public class SbClient
{
    private readonly IConfiguration _config;
    public SbClient(IConfiguration config) => _config = config;

    public async Task SendMessage()
    {
        ServiceBusClient client;
        ServiceBusSender sender;

        const int numOfMessages = 3;

        var clientOptions = new ServiceBusClientOptions()
        {
            TransportType = ServiceBusTransportType.AmqpWebSockets
        };

        var connString = _config["ConnectionStrings:ASB_CONN_STRING"];
        var queName = _config["QUEUE_NAME"];

        client = new ServiceBusClient(connString, clientOptions);
        sender = client.CreateSender(queName);

        // create a batch 
        //using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
        ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();


        for (int i = 1; i <= numOfMessages; i++)
        {
            // try adding a message to the batch
            if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
            {
                // if it is too large for the batch
                throw new Exception($"The message {i} is too large to fit in the batch.");
            }
        }

        try
        {
            // Use the producer client to send the batch of messages to the Service Bus queue
            await sender.SendMessagesAsync(messageBatch);
            WriteLine($"A batch of {numOfMessages} messages has been published to the queue.");
        }
        finally
        {
            // Calling DisposeAsync on client types is required to ensure that network
            // resources and other unmanaged objects are properly cleaned up.
            await sender.DisposeAsync();
            await client.DisposeAsync();
        }

        WriteLine("Press any key to end the application");
        ReadKey();
    }
}