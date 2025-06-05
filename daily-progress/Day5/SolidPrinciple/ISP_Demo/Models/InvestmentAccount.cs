using ISP_Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_Demo.Models
{
    public class InvestmentAccount : IInvestmentAccount
    {
        private decimal balance;
        private int shares;

        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount:C} \nCurrent Balance: {balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew {amount:C} \nCurrent Balance: {balance:C}");
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

        public void Buyshares(int numberOfShares)
        {
            shares += numberOfShares;
            Console.WriteLine($"Bought {numberOfShares} shares. Total Shares = {shares}");
        }

        public void SellShares(int numberOfShares)
        {
            if (numberOfShares <= shares)
            {
                shares -= numberOfShares;
                Console.WriteLine($"Sold {numberOfShares} shares. Remaining Shares = {shares}");
            }
            else
            {
                Console.WriteLine("Not enough shares to sell.");
            }
        }
    }
}
