namespace ConAppStrategyPattern;

public record Order(string Customer, int Amount, string Name, IExportSvc ExportService) 
{
	public void Export()
	{
		ExportService?.Export(this);
	}
}
