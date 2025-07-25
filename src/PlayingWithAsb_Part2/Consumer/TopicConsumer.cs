using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using static System.Console;

namespace PlayingWithAsb_Part2.Consumer;
public class TopicConsumer(IConfiguration config)
{
	private readonly IConfiguration _config = config;
	private ServiceBusProcessor? _processor;

	public async Task StartReceivingAsync(CancellationToken cancellationToken = default)
	{
		var connectionString = _config["ConnectionStrings:ASB_CONN_STRING"];
		var topicName = _config["TOPIC_NAME"];
		var subscriptionName = _config["SUBSCRIPTION_NAME"];

		var clientOptions = new ServiceBusClientOptions()
		{
			TransportType = ServiceBusTransportType.AmqpWebSockets
		};

		var client = new ServiceBusClient(connectionString, clientOptions);

		var processorOptions = new ServiceBusProcessorOptions
		{
			MaxConcurrentCalls = 1,
			AutoCompleteMessages = false
		};

		_processor = client.CreateProcessor(topicName, subscriptionName, processorOptions);

		_processor.ProcessMessageAsync += MessageHandler;
		_processor.ProcessErrorAsync += ErrorHandler;

		await _processor.StartProcessingAsync(cancellationToken);
		Console.WriteLine($"Started processing messages from topic '{topicName}', subscription '{subscriptionName}'");
	}

	public async Task StopReceivingAsync()
	{
		if (_processor != null)
		{
			await _processor.StopProcessingAsync();
			await _processor.DisposeAsync();
			WriteLine("Stopped processing messages");
		}
	}

	private async Task MessageHandler(ProcessMessageEventArgs args)
	{
		try
		{
			var message = args.Message.Body.ToString();
			WriteLine($"Received message: {message}");
			WriteLine($"Message ID: {args.Message.MessageId}");
			WriteLine($"Subject: {args.Message.Subject}");

			await args.CompleteMessageAsync(args.Message);
			WriteLine("Message processed successfully");
		}
		catch (Exception ex)
		{
			WriteLine($"Error processing message: {ex.Message}");
			// Abandon the message so it can be retried
			await args.AbandonMessageAsync(args.Message);
		}
	}

	private Task ErrorHandler(ProcessErrorEventArgs args)
	{
		WriteLine($"Error occurred: {args.Exception.Message}");
		return Task.CompletedTask;
	}
}
