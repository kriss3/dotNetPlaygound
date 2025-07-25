using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

using static System.Console;

namespace PlayingWithAsb_Part2.Producer;
public class TopicProducer(IConfiguration config)
{
	private readonly IConfiguration _config = config;

	public async Task SendMessageAsync(string message)
	{
		var connectionString = _config["ConnectionStrings:ASB_CONN_STRING"];
		var topicName = _config["TOPIC_NAME"];

		var clientOptions = new ServiceBusClientOptions()
		{
			TransportType = ServiceBusTransportType.AmqpWebSockets
		};

		await using var client = new ServiceBusClient(connectionString, clientOptions);
		await using var sender = client.CreateSender(topicName);

		var serviceBusMessage = new ServiceBusMessage(message)
		{
			MessageId = Guid.NewGuid().ToString(),
			Subject = "Topic Message"
		};

		try
		{
			await sender.SendMessageAsync(serviceBusMessage);
			WriteLine($"Message sent to topic '{topicName}': {message}");
		}
		catch (Exception ex)
		{
			WriteLine($"Error sending message: {ex.Message}");
			throw;
		}
	}
}
