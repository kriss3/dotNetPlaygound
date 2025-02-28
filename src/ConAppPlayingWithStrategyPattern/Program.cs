
using static System.Console;

namespace ConAppPlayingWithStrategyPattern;

internal class Program
{
	static void Main()
	{
		WriteLine("Playing with the Strategy Pattern!");
		Run();
	}

	private static void Run() 
	{
		var paymentContext = new PaymentContext();

		WriteLine("Select a payment method: 1. Credit Card  2. PayPal  3. Bitcoin");
		string choice = ReadLine();



	}
}
