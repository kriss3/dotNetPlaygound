using System.Security;

namespace ConAppPlayingWithAdapterPattern.Example_3;
public interface ILogger 
{ 
	void Log(string message); 
}

public sealed class XmlAuditLogger
{
	public void WriteXml(string xml) { /* writes to audit sink */ }
}

public sealed class XmlLoggerAdapter(XmlAuditLogger logger) : ILogger
{
	private readonly XmlAuditLogger _logger = logger;

	public void Log(string message)
	{
		var xml = $"<log><timestamp>{DateTime.UtcNow:o}</timestamp><msg>{SecurityElement.Escape(message)}</msg></log>";
		_logger.WriteXml(xml);
	}
}


