
using System.Runtime.InteropServices;
using static System.Console;
namespace ConAppStrategyPattern;

public class Program
{
	static async Task Main(string[] args)
	{
		await Task.Run(() => 
		{
			Prompt();
			Run();
		}); 
	}

	private static void Prompt() 
	{
		WriteLine("Description: " +
		"Strategy Patterns, one of the behavior patterns aka Policy pattern." +
		"Client decides during the run time which 'algorithm' to execute." +
		"Example will use Export (csv, excel, json etc) but other use cases could be Payment methods.");
	}

	private static void Run() 
	{
		WriteLine("This is a Drive for the first Strategy pattern implementation." +
			"Order class/record contains a variant property that client can use to decide on Strategy.");

		WriteLine("Strategy v1.");

		var order = new Order("Kris Software", 10, "Strategy", new JsonExportService());
		order.Export();

		//Same order but different strategy.
		var order2 = order with { ExportService = new ExcelExportService() };
		order2.Export();
	
	}
}
