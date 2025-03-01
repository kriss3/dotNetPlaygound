
using ConAppPlayingWithStrategyPattern.ConcreteStrategies;
using static System.Console;

namespace ConAppPlayingWithStrategyPattern;

internal class Program
{
	static void Main()
	{
		WriteLine("Playing with the Strategy Pattern!");
		Run();
		RunWithUnionType();
	}

	private static void Run() 
	{
		var paymentContext = new PaymentContext();

		WriteLine("Select a payment method: 1. Credit Card  2. PayPal  3. Bitcoin");
		string choice = ReadLine() ?? "4";

		switch (choice)
		{
			case "1":
				paymentContext.SetPaymentStrategy(new CreditCardPayment());
				break;
			case "2":
				paymentContext.SetPaymentStrategy(new PayPalPayment());
				break;
			case "3":
				paymentContext.SetPaymentStrategy(new BitcoinPayment());
				break;
			default:
				WriteLine("Invalid choice.");
				return;
		}

		Write("Enter amount to pay: ");
		if (decimal.TryParse(ReadLine(), out decimal amount))
		{
			paymentContext.ProcessPayment(amount);
		}
		else
		{
			WriteLine("Invalid amount.");
		}

	}

	private static void RunWithUnionType()
	{
		WriteLine("Select a payment method: /n1. Credit Card  /n2. PayPal  /n3. Bitcoin");
		string? choice = ReadLine();

		if (choice is null)
		{
			WriteLine("Invalid choice.");
			return;
		}

		var paymentMethods = new Dictionary<string, PaymentMethod>
		{
			{ "1", new CreditCard() },
			{ "2", new PayPal() },
			{ "3", new Bitcoin() }
		};
	}
}
