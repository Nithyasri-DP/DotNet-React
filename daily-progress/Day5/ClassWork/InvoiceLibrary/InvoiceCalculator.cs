namespace InvoiceLibrary
{
    public class InvoiceCalculator
    {
        private static int invoiceCounter = 1000;

        public decimal CalculateTotal(decimal amount, decimal taxRatePercent)
        {
            decimal tax = amount * taxRatePercent / 100;
            return amount + tax;
        }

        public decimal ApplyDiscount(decimal amount, decimal discountPercent)
        {
            decimal discount = amount * discountPercent / 100;
            return amount - discount;
        }

        public string GenerateInvoiceNumber()
        {
            invoiceCounter++;
            return $"INV{invoiceCounter}";
        }

        public string GetInvoiceSummary(decimal baseAmount, decimal taxRate, decimal discountRate)
        {
            decimal discounted = ApplyDiscount(baseAmount, discountRate);
            decimal total = CalculateTotal(discounted, taxRate);

            return $"Subtotal: {baseAmount}\n" +
                   $"Discount ({discountRate}%): {baseAmount - discounted}\n" +
                   $"Tax ({taxRate}%): {total - discounted}\n" +
                   $"Total Payable: {total}";
        }
    }
}
