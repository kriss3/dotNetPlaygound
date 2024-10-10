namespace ConAppStrategyPattern;

public class ExcelExportService : IExportSvc
{
	public void Export(Order order) 
	{
		Console.WriteLine($"Exporting {order.Name} to MS Excel");
	}
}
