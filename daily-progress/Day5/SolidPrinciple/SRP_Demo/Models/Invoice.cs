using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Demo.Models
{
    internal class Invoice
    {
        public long InvoiceAmount { get; set; }
        public DateTime InvoiceDate { get; set; }

        public void AddInvoice()
        {
            Console.WriteLine("Invoice Added");

            MailSender mailSender = new MailSender();
            mailSender.SendEmail();
        }

        public void RemoveInvoice()
        {
            Console.WriteLine("Invoice Removed");
        }
    }
}
