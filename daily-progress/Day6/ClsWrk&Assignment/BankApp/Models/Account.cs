using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Account
    {
        public string? AccountNumber { get; set; }

        public string? AccountHolderName { get; set; }

        public decimal Balance { get; set; }
    }
}
