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
}
