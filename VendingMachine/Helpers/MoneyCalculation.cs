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
            int amountCents = this.ConvertMoneyToCent(amount);
            int currentCents = this.ConvertMoneyToCent(currentMoney);

            int sumCents = currentCents + amountCents;
            
            return ConvertCentsToMoney(currentMoney, sumCents);
        }

        public Money Subtract(Money amount, Money currentMoney)
        {
            int amountCents = this.ConvertMoneyToCent(amount);
            int currentCents = this.ConvertMoneyToCent(currentMoney);

            int sumCents = currentCents - amountCents;
            
            return ConvertCentsToMoney(currentMoney, sumCents);
        }

        private int ConvertMoneyToCent(Money amount)
        {
            return amount.Euros * 100 + amount.Cents;
        }

        private Money ConvertCentsToMoney(Money currentMoney, int sumCents)
        {
            currentMoney.Euros = sumCents / 100;
            currentMoney.Cents = sumCents % 100;

            return currentMoney;
        }
    }
}
