using static System.Console;

namespace ConAppPlayingWithMassTransit;

public class Program
{
	static void Main(string[] args)
	{
		WriteLine("This is MassTransit - library for abstracting exchanging messages between systems.");
	}
}

public class PublisherService(IBus bus, ILogger<PublisherService> log) : BackgroundService
{ }

public class HelloConsumer(ILogger<HelloConsumer> log) : IConsumer<Hello>
{ }
