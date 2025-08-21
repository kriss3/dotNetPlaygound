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
	public virtual void Request() 
	{
		WriteLine("Called Target Request()");
	}
}

public class Adapter : Target 
{
	private readonly Adaptee _adaptee = new();
	public override void Request() 
	{
		_adaptee.SpecificRequest();
	}
}

public class Adaptee
{

	public void SpecificRequest()
	{
		WriteLine("Called SpecificRequest()");
	}
}
