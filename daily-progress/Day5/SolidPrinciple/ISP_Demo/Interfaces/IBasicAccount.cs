using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_Demo.Interfaces
{
    public interface IBasicAccount
    {
        void Withdraw(decimal amount);
        void Deposit(decimal amount);
        void CheckBalance(int accountNumber);
    }
}
