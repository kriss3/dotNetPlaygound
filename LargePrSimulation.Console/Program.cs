using LargePrSimulation.Library;
using static System.Console;

namespace LargePrSimulation.Console;

public class Program
{
	static void Main(string[] args)
	{
		WriteLine("Hello, World!");
		Run();
	}

	private static void Run() 
	{
		var result = GreetingService.GetGreeting("World!");
		WriteLine(result);
	}
}
