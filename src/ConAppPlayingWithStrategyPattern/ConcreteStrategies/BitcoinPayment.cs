using ConAppPlayingWithStrategyPattern.Interfaces;

namespace ConAppPlayingWithStrategyPattern.ConcreteStrategies;

public class BitcoinPayment : IPaymentStrategy
{
	public void Pay(decimal amount)
	{
		throw new NotImplementedException();
	}
}
