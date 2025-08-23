namespace ConAppPlayingWithAdapterPattern.Example_3;
public interface ILogger 
{ 
	void Log(string message); 
}

public sealed class XmlAuditLogger
{
	public void WriteXml(string xml) { /* writes to audit sink */ }
}


