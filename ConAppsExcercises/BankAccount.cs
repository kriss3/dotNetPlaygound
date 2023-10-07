using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppsExercises
{
    public class BankAccount
    {
        public string CustomerName { get; set; }
        public double Balance { get; set; }

        public BankAccount(string customerName, double balance)
        {
            CustomerName = customerName;
            Balance = balance;
        }

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
}
