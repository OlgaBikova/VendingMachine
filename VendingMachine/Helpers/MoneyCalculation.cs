using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Helpers
{
    public class MoneyCalculation : IMoneyCalculation
    {
        public Money Add(Money amount, Money currentMoney)
        {
            int amountCents = this.ConvertToCent(amount);
            int currentCents = this.ConvertToCent(currentMoney);

            int sumCents = currentCents + amountCents;

            currentMoney.Euros = sumCents / 100;
            currentMoney.Cents = sumCents % 100;

            return currentMoney;
        }

        public Money Subtract(Money amount, Money currentMoney)
        {
            int amountCents = this.ConvertToCent(amount);
            int currentCents = this.ConvertToCent(currentMoney);

            int sumCents = currentCents - amountCents;

            currentMoney.Euros = sumCents / 100;
            currentMoney.Cents = sumCents % 100;

            return currentMoney;
        }

        private int ConvertToCent(Money amount)
        {
            return amount.Euros * 100 + amount.Cents;
        }
    }
}
