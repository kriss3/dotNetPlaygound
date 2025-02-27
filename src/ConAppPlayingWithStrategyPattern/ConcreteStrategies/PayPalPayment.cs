using ConAppPlayingWithStrategyPattern.Interfaces;
using static System.Console;

namespace ConAppPlayingWithStrategyPattern.ConcreteStrategies;

public class PayPalPayment : IPaymentStrategy
{
	public void Pay(decimal amount)
	{
		WriteLine($"Paid {amount:C} using PayPal payment option.");
	}
}
