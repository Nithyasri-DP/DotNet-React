using OCP_Demo.Models;

namespace OCP_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Invoice finalInvoice = new FinalInvoice();
            Console.WriteLine("Final Invoice Amount: " + finalInvoice.GetInvoiceDiscount(1000));

            Invoice proposedInvoice = new ProposedInvoice();
            Console.WriteLine("Proposed Invoice Amount: " + proposedInvoice.GetInvoiceDiscount(1000));

            Invoice recurringInvoice = new RecurringInvoice();
            Console.WriteLine("Recurring Invoice Amount: " + recurringInvoice.GetInvoiceDiscount(1000));
        }
    }
}
