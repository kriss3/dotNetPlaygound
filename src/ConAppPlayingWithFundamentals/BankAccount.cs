using System;

namespace ConAppPlayingWithFundamentals;

public class BankAccount(string customerName, double balance)
{
	public string CustomerName { get; set; } = customerName;
	public double Balance { get; set; } = balance;

	public void Debit(double amount)
	{
		if (Balance == 0)
		{
			throw new Exception("Balance is 0");
		}
		if (amount <= 0 || amount > Balance)
		{
			throw new ArgumentOutOfRangeException(nameof(amount), "Amount <=0 or Amount > Balance");
		}
		Balance -= amount;
	}

	public void Credit(double amount)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
		Balance += amount;
	}
}
