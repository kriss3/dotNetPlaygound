namespace ConAppStrategyPattern;

public record Order(string Customer, int Amount, string Name) 
{
	public void Export(IExportSvc svc)
	{
		ArgumentNullException.ThrowIfNull(svc);
		svc?.Export(this);
	}
}
