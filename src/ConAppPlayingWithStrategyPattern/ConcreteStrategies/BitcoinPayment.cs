using ConAppPlayingWithStrategyPattern.Interfaces;
using static System.Console;

namespace ConAppPlayingWithStrategyPattern.ConcreteStrategies;

public class BitcoinPayment : IPaymentStrategy
{
	public void Pay(decimal amount)
	{
		WriteLine($"Paid {amount:C} using Bitcoin payment.");
	}
}
