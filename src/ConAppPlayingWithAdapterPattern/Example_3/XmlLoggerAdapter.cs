using System.Security;

namespace ConAppPlayingWithAdapterPattern.Example_3;

public sealed class XmlLoggerAdapter() : ILogger
{
	public void Log(string message)
	{
		var xml = $"<log><timestamp>{DateTime.UtcNow:o}</timestamp><msg>{SecurityElement.Escape(message)}</msg></log>";
		XmlAuditLogger.WriteXml(xml);
	}
}
