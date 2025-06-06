using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public interface IBankRepository
    {
        Account GetAccount(string accountNumber); 
        void UpdateAccount(Account account);
    }
}
