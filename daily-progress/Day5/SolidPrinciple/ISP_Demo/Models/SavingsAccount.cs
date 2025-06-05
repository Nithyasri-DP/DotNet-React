using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISP_Demo.Interfaces;

namespace ISP_Demo.Models
{
    public class SavingsAccount : IBasicAccount
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine("Deposited " + amount.ToString("C", new CultureInfo("en-IN")));
            Console.WriteLine("Current Balance: " + balance.ToString("C", new CultureInfo("en-IN")));
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Withdrew " + amount.ToString("C", new CultureInfo("en-US")));
                Console.WriteLine("Current Balance: " + balance);
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public void CheckBalance(int accountNumber)
        {
            Console.WriteLine($"Current Balance = {balance}");
        }
    }
}
