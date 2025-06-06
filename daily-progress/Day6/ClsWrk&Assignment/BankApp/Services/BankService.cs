using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class BankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public decimal Deposit(string accountNumber, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0");

            var acc = _bankRepository.GetAccount(accountNumber);

            if (acc == null)
                throw new InvalidOperationException("Account Number not Found");

            acc.Balance += amount;
            _bankRepository.UpdateAccount(acc);

            return acc.Balance;
        }

        public decimal Withdraw(string accountNumber, decimal amount)
        {
            var acc = _bankRepository.GetAccount(accountNumber);

            if (acc == null)
                throw new InvalidOperationException("Account Number Not Valid");

            if (amount > acc.Balance)
                throw new InvalidOperationException("Insufficient Funds");

            acc.Balance -= amount;
            _bankRepository.UpdateAccount(acc);

            return acc.Balance;
        }
    }
}
