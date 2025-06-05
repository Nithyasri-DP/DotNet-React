using SRP_Demo.Models;

namespace SOLID_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice();
            invoice.AddInvoice();
            invoice.RemoveInvoice();
        }
    }
}
