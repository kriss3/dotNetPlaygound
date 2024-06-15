using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppStrategyPattern;
public interface IExportSvc
{
	void Export(Order order);
}

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

public class JsonExportService : IExportSvc
{
	public void Export(Order order) 
	{
		Console.WriteLine($"Exporting {order.Name} to JSON");
	}
}

public class ExcelExportService : IExportSvc
{
	public void Export(Order order) 
	{
		Console.WriteLine($"Exporting {order.Name} to MS Excel");
	}
}


public record Order(string Name);
