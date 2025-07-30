namespace PlayingWithAsb_Part2;

using Microsoft.Extensions.Configuration;
using PlayingWithAsb_Part2.Consumer;
using PlayingWithAsb_Part2.Producer;
using static System.Console;

public class Program
{
	static async Task Main()
	{
		WriteLine("Azure Service Bus Topic Producer/Consumer Demo");

		// Setup configuration
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			.Build();

		var producer = new TopicProducer(configuration);
		var consumer = new TopicConsumer(configuration);

		using var cancellationTokenSource = new CancellationTokenSource();

		try
		{
			// Start the consumer in the background
			Console.WriteLine("Starting consumer...");
			await consumer.StartReceivingAsync(cancellationTokenSource.Token);

			// Give consumer time to start
			await Task.Delay(2000);

			// Send some messages
			Console.WriteLine("\nSending messages...");
			await producer.SendMessageAsync("Hello from Producer!");
			await producer.SendMessageAsync("Second message from Producer!");

			// Send batch messages
			var batchMessages = new[] { "Batch Message 1", "Batch Message 2", "Batch Message 3" };
			await producer.SendBatchMessagesAsync(batchMessages);

			// Let messages process
			Console.WriteLine("\nProcessing messages... Press any key to stop.");
			Console.ReadKey();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
	}
}
