using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP_Demo.Models
{
    public class Invoice
    {
        protected const double BaseDiscount = 100;

        public virtual double GetInvoiceDiscount(double amount)
        {
            return amount - BaseDiscount;
        }
    }
}
