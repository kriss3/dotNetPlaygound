namespace PlayingWithAsb_Part2;

using Microsoft.Extensions.Configuration;
using PlayingWithAsb_Part2.Consumer;
using PlayingWithAsb_Part2.Producer;
using static System.Console;

public class Program
{
	static void Main()
	{
		WriteLine("Azure Service Bus Topic Producer/Consumer Demo");

		// Setup configuration
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			.Build();

		var producer = new TopicProducer(configuration);
		var consumer = new TopicConsumer(configuration);

	}
}
