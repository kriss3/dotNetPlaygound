namespace ConAppPlayingWithAdapterPattern.Example_3;
public interface ILogger 
{ 
	void Log(string message); 
}

public sealed class XmlAuditLogger
{
	public void WriteXml(string xml) { /* writes to audit sink */ }
}

public sealed class XmlLoggerAdapter : ILogger
{
	private readonly XmlAuditLogger _logger;
	public XmlLoggerAdapter(XmlAuditLogger logger)
	{
		_logger = logger;
	}

	public void Log(string message)
	{
		throw new NotImplementedException();
	}
}


