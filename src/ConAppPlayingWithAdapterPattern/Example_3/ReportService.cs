namespace ConAppPlayingWithAdapterPattern.Example_3;

public sealed class ReportService(ILogger logger)
{
	private readonly ILogger _logger = logger;

	public void Run() => _logger.Log("Report executed.");
}
