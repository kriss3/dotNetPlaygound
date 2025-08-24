using System.Security;

namespace ConAppPlayingWithAdapterPattern.Example_3;
public interface ILogger 
{ 
	void Log(string message); 
}

public sealed class XmlLoggerAdapter() : ILogger
{
	public void Log(string message)
	{
		var xml = $"<log><timestamp>{DateTime.UtcNow:o}</timestamp><msg>{SecurityElement.Escape(message)}</msg></log>";
		XmlAuditLogger.WriteXml(xml);
	}
}

public sealed class ReportService(ILogger logger)
{
	private readonly ILogger _logger = logger;

	public void Run() => _logger.Log("Report executed.");
}
