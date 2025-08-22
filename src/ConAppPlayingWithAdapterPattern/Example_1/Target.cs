using static System.Console;

namespace ConAppPlayingWithAdapterPattern.Example_1;

public abstract class Target 
{
	public virtual void Request() 
	{
		WriteLine("Called Target Request()");
	}
}
