using System;

namespace ConAppsExercises;

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
            throw new ArgumentOutOfRangeException("Amount <=0 or Amount > Balance");
        }
        Balance = -amount;
    }

    public void Credit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Amount <= 0");
        }
        Balance += amount;
    }
}
