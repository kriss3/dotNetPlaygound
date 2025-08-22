namespace ConAppPlayingWithAdapterPattern.Example_1;

public class Adapter : Target 
{
	private readonly Adaptee _adaptee = new();
	public override void Request() 
	{
		_adaptee.SpecificRequest();
	}
}
