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

	public async Task SendBatchMessagesAsync(IEnumerable<string> messages)
	{
		var connectionString = _config["ConnectionStrings:ASB_CONN_STRING"];
		var topicName = _config["TOPIC_NAME"];

		var clientOptions = new ServiceBusClientOptions()
		{
			TransportType = ServiceBusTransportType.AmqpWebSockets
		};

		await using var client = new ServiceBusClient(connectionString, clientOptions);
		await using var sender = client.CreateSender(topicName);

		using var messageBatch = await sender.CreateMessageBatchAsync();

		foreach (var message in messages)
		{
			var serviceBusMessage = new ServiceBusMessage(message)
			{
				MessageId = Guid.NewGuid().ToString(),
				Subject = "Batch Message"
			};

			if (!messageBatch.TryAddMessage(serviceBusMessage))
			{
				throw new Exception($"The message '{message}' is too large to fit in the batch.");
			}
		}

		try
		{
			await sender.SendMessagesAsync(messageBatch);
			Console.WriteLine($"Batch of {messageBatch.Count} messages sent to topic '{topicName}'");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error sending batch messages: {ex.Message}");
			throw;
		}
	}
}
