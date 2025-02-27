using ConAppPlayingWithStrategyPattern.Interfaces;
using static System.Console;

namespace ConAppPlayingWithStrategyPattern.ConcreteStrategies;
public class CreditCardPayment : IPaymentStrategy
{
	public void Pay(decimal amount)
	{
		WriteLine($"Paid {amount:C} using Credit Card.");
	}
}
