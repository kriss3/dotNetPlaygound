namespace ConAppStrategyPattern;

/// <summary>
/// Concrete Strategy here...
/// </summary>
public class XmlExportService : IExportSvc 
{
	public void Export(Order order) 
	{
		Console.WriteLine($"Exporting {order.Name} to XML.");
	}
}
