using Serilog;
using Serilog.Events;

namespace WebsiteStatus;

public class Program
{
	public static void Main(string[] args)
	{

		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
			.Enrich.FromLogContext()
			.WriteTo.File(@"C:\temp\WebsiteStatus\HealthCheck.txt")
			.CreateLogger();

		try
		{
			Log.Information("Starting up the service");

			var builder = Host.CreateApplicationBuilder(args);
			builder.Services.AddHostedService<Worker>();
			builder.Logging.AddSerilog();

			var host = builder.Build();
			host.Run();
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
}