
using static System.Console;
namespace ConAppStrategyPattern;

public class Program
{
	static async Task Main(string[] args)
	{
		await Task.Run(() => 
		WriteLine("Description: " +
		"Strategy Patterns, one of the behavior patterns aka Policy pattern." +
		"Client decides during the run time which 'algorithm' to execute." +
		"Example will use Export (csv, excel, json etc) but other use cases could be Payment methods.")); 
	}
}
