using ConAppPlayingWithStrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace ConAppPlayingWithStrategyPattern.ConcreteStrategies;
public class CreditCardPayment : IPaymentStrategy
{
	public void Pay(decimal amount)
	{
		WriteLine($"Paid {amount:C} using Credit Card.");
	}
}
