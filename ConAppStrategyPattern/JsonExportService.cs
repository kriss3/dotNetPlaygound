namespace ConAppStrategyPattern;

public class JsonExportService : IExportSvc
{
	public void Export(Order order) 
	{
		Console.WriteLine($"Exporting {order.Name} to JSON");
	}
}
