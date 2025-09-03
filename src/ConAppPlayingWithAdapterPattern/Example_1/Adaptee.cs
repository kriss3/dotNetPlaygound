using static System.Console;

namespace ConAppPlayingWithAdapterPattern.Example_1;

public class Adaptee
{
	public static void SpecificRequest()
	{
		WriteLine("Called SpecificRequest()");
	}
}
