using static System.Console;

namespace ConAppPlayingWithAdapterPattern.Example_1;

public class Adaptee
{
	public void SpecificRequest()
	{
		WriteLine("Called SpecificRequest()");
	}
}
