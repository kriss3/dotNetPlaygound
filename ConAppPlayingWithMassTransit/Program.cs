
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static MassTransit.MessageHeaders;
using static MassTransit.Monitoring.Performance.BuiltInCounters;
using static MassTransit.Util.ChartTable;

//Adding Aliases:
using MsHost = Microsoft.Extensions.Hosting.Host;
using MsIHost = Microsoft.Extensions.Hosting.IHost;
using MsIHostBuilder = Microsoft.Extensions.Hosting.IHostBuilder;


using static System.Console;


namespace ConAppPlayingWithMassTransit;

public class Program
{
	public static async Task Main(string[] args)
	{
		WriteLine("This is MassTransit - library for abstracting exchanging messages between systems.");
	}

	private static MsIHostBuilder CreateHostBuilder(string[] args) =>
		MsHost.CreateDefaultBuilder(args)
			.ConfigureServices((ctx, services) =>
			{
				services.AddLogging(b => b.AddConsole());

				services.AddMassTransit(x =>
				{
					x.AddConsumer<HelloConsumer>();

					x.UsingInMemory((context, cfg) =>
					{
						cfg.ConfigureEndpoints(context);
					});
				});

				services.AddHostedService<PublisherService>();
			});

}

public record Hello(string Name);

public class PublisherService(IBus bus, ILogger<PublisherService> log) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		// Publish a few messages, then keep the host alive

		for (var i = 1; i <= 5 && !stoppingToken.IsCancellationRequested; i++)
		{
			var name = $"Kris #{i}";
			await bus.Publish(new Hello(name), stoppingToken);
			log.LogInformation("📤 Published Hello({Name})", name);
			await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
		}

		// No-op loop to keep the process running so consumption can be seen.
		while (!stoppingToken.IsCancellationRequested)
			await Task.Delay(1000, stoppingToken);

	}
}

public class HelloConsumer(ILogger<HelloConsumer> log) : IConsumer<Hello>
{
	public Task Consume(ConsumeContext<Hello> ctx)
	{
		log.LogInformation("✅ Consumed Hello for {Name}", ctx.Message.Name);
		return Task.CompletedTask;
	}
}


