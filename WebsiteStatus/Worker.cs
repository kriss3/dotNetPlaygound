namespace WebsiteStatus;

public class Worker(ILogger<Worker> logger) : BackgroundService
{
	private readonly ILogger<Worker> _logger = logger;
	private HttpClient? client;

	public override Task StartAsync(CancellationToken cancellationToken)
	{
		client = new HttpClient();
		return base.StartAsync(cancellationToken);
	}

	public override Task StopAsync(CancellationToken cancellationToken)
	{
		client?.Dispose();
		return base.StopAsync(cancellationToken);	
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			var result = await client!.GetAsync("https://www.google.ca");
			if (result.IsSuccessStatusCode)
			{
				_logger.LogInformation("The website is up {StatusCode}", result.StatusCode);
			}
			else 
			{
				_logger.LogError("The website is down {StatusCode}", result.StatusCode);

			}

			await Task.Delay(5000, stoppingToken); // pattern: 60*1000 a minute
		}
	}
}
