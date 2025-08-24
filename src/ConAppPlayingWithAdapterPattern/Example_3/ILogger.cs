namespace ConAppPlayingWithAdapterPattern.Example_3;
public interface ILogger 
{ 
	void Log(string message); 
}

public sealed class ReportService(ILogger logger)
{
	private readonly ILogger _logger = logger;

	public void Run() => _logger.Log("Report executed.");
}
