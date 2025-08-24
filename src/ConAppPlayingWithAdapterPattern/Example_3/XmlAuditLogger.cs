namespace ConAppPlayingWithAdapterPattern.Example_3;

public sealed class XmlAuditLogger
{
	public static void WriteXml(string xml) 
	{
		var x = $"Adding log including message in {xml}";
	}
}
