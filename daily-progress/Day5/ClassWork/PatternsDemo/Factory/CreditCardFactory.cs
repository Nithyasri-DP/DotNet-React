using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsDemo.Factory
{
    public class MoneyBack : ICreditCard
    {
        public string GetCardType() => "MoneyBack";
        public int GetCreditLimit() => 45000;
        public int GetAnnualCharge() => 3000;
    }

    public class Titanium : ICreditCard
    {
        public string GetCardType() => "Titanium card";
        public int GetCreditLimit() => 145000;
        public int GetAnnualCharge() => 5000;
    }

    public class CreditCardFactory
    {
        public static ICreditCard GetCreditCard(string cardType)
        {
            switch (cardType.ToLower())
            {
                case "moneyback":
                    return new MoneyBack();
                case "titanium":
                    return new Titanium();
                default:
                    return null;
            }
        }
    }
}
