using System;

namespace VendingMachine.Helpers
{
    public class MoneyComparer : IMoneyComparer
    {
        public int Compare(Money amount, Money productPrice)
        {
            int euroDiff = amount.Euros - productPrice.Euros;
            int centDiff = amount.Cents - productPrice.Cents;

            if (euroDiff != 0)
                return euroDiff;

            if (centDiff != 0)
                return centDiff;

            return 0;
        }
    }
}
