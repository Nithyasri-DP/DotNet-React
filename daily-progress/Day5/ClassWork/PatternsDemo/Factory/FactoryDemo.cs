using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsDemo.Factory
{
    public static class FactoryDemo
    {
        public static void Run()
        {
            Console.WriteLine("Enter the card type (MoneyBack / Titanium):");
            string cardType = Console.ReadLine();

            ICreditCard card = CreditCardFactory.GetCreditCard(cardType);

            if (card != null)
            {
                Console.WriteLine($"Card Type: {card.GetCardType()}");
                Console.WriteLine($"Credit Limit: {card.GetCreditLimit()}");
                Console.WriteLine($"Annual Charge: {card.GetAnnualCharge()}");
            }
            else
            {
                Console.WriteLine("Invalid card type entered.");
            }
        }
    }
}
