using ConAppPlayingWithAdapterPattern.Example_1;
using static System.Console;

namespace ConAppPlayingWithAdapterPattern;

public class Program
{
	static Task Main()
	{
		WriteLine("Hello, World!");
		Execute_Example_1();
		return Task.CompletedTask;
	}

	private static void Execute_Example_1() 
	{
		Target target = new Adapter();
		target.Request();
		// Wait for user
		ReadKey();
	}
}
