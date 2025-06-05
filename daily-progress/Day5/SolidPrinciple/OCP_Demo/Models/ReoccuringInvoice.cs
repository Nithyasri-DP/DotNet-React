using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP_Demo.Models
{
    public class RecurringInvoice : Invoice
    {
        private const double ExtraDiscount = 300;

        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - ExtraDiscount;
        }
    }
}
