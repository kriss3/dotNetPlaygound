using ConAppPlayingWithStrategyPattern.Interfaces;

namespace ConAppPlayingWithStrategyPattern.ConcreteStrategies;

public class PayPalPayment : IPaymentStrategy
{
	public void Pay(decimal amount)
	{
		throw new NotImplementedException();
	}
}
