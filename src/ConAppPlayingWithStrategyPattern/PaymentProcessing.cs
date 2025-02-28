using ConAppPlayingWithStrategyPattern.ConcreteStrategies;

using static System.Console;

namespace ConAppPlayingWithStrategyPattern;
public class PaymentProcessing
{
	public static void ProcessPayment(PaymentMethod method, decimal amount) 
	{
		string message = method switch
		{
			CreditCard => $"Paid {amount:C} using Credit Card.",
			PayPal => $"Paid {amount:C} using PayPal payment option.",
			Bitcoin => $"Paid {amount:C} using Bitcoin payment.",
			_ => "Invalid choice."
		};

		WriteLine(message);
	}
}
