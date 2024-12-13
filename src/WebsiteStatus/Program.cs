using Serilog;
using Serilog.Events;

namespace WebsiteStatus;

public class Program
{
	public static async Task Main(string[] args)
	{
		GetLogger();
		await Run(args);
	}

	private static async Task Run(string[] args)
	{
		try
		{
			Log.Information("Starting up the service");

			var builder = Host.CreateApplicationBuilder(args);
				
			builder.Services.AddHostedService<Worker>()
				.AddWindowsService();
			builder.Logging
				.AddSerilog();

			var host = builder.Build();
			await host.RunAsync();
		}
		catch (Exception ex)
		{
			Log.Fatal($"There was a problem starting the service. Error:{ex.Message}");
			return;
		}
		finally
		{
			Log.CloseAndFlush();
		}
	}

	private static void GetLogger()
	{
		Log.Logger = new LoggerConfiguration()
					.MinimumLevel.Debug()
					.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
					.Enrich.FromLogContext()
					.WriteTo.File(@"C:\temp\WebsiteStatus\HealthCheck.txt")
					.CreateLogger();
	}
}