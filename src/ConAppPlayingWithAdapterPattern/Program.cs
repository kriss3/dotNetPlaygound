using static System.Console;

namespace ConAppPlayingWithAdapterPattern;

public class Program
{
	static Task Main()
	{
		WriteLine("Hello, World!");
		return Task.CompletedTask;
	}

	private static void Execute() 
	{
		Target target = new Adapter();
		target.Request();
		// Wait for user
		ReadKey();
	}
}

public abstract class Target 
{
	public virtual void Request() { }
}

public class Adapter : Target 
{
	public override void Request() { }
}
