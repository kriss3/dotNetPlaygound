using ConAppPlayingWithStrategyPattern.Interfaces;
using static System.Console;

namespace ConAppPlayingWithStrategyPattern;
public class PaymentContext
{
	private IPaymentStrategy? _payStrategy;

	public void SetPaymentStrategy(IPaymentStrategy paymentStrategy) 
	{
		_payStrategy = paymentStrategy;
	}

	public void ProcessPayment(decimal amount) 
	{
		if (_payStrategy is null)
		{
			WriteLine("Select payment method first!");
			return;
		}
		_payStrategy.Pay(amount);
	}
}
