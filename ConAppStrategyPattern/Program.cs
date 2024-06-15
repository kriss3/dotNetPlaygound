
using static System.Console;
namespace ConAppStrategyPattern;

public class Program
{
	static async Task Main(string[] args)
	{
		await Task.Run(() => WriteLine("Hello, World!")); 
	}
}
