using ConAppPlayingWithStrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithStrategyPattern.ConcreteStrategies;
public class CreditCardPayment : IPaymentStrategy
{
	public void Pay(decimal amount)
	{
		throw new NotImplementedException();
	}
}

public class BitcoinPayment : IPaymentStrategy
{
	public void Pay(decimal amount)
	{
		throw new NotImplementedException();
	}
}
