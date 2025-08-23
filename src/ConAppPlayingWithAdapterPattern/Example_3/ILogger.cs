using System.Security;

namespace ConAppPlayingWithAdapterPattern.Example_3;
public interface ILogger 
{ 
	void Log(string message); 
}

public sealed class XmlAuditLogger
{
	public static void WriteXml(string xml) 
	{
		var x = $"Adding log including message in {xml}";
	}
}

public sealed class XmlLoggerAdapter() : ILogger
{
	public void Log(string message)
	{
		var xml = $"<log><timestamp>{DateTime.UtcNow:o}</timestamp><msg>{SecurityElement.Escape(message)}</msg></log>";
		XmlAuditLogger.WriteXml(xml);
	}
}
