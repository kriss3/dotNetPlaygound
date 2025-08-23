using ConAppPlayingWithAdapterPattern.Example_1;
using ConAppPlayingWithAdapterPattern.Example_2;
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

	private static void Execute_Example_2() 
	{
		var checkout = new CheckoutService(new LegacyGatewayAdapter(new LegacyGateway()));
		var ok = checkout.PayOrder("4111111111111111", 49.99m);
		WriteLine($"The payment via Payment Adapter went: {ok}");
	}
	//start with example 3.(Logging: adapt an XML-only logger to ILogger)

/*
 * 
 * 
 classDiagram
Client --> Target : calls
Adapter ..|> Target : implements
Adapter o--> Adaptee : wraps
class Client
class Target{
	<<interface>>
	+request()
}
class Adaptee{
	+specificRequest()
}
class Adapter{
	-Adaptee adaptee
	+request()
}
//Diagram.
*/ 
}
