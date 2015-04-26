using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class MoneyValidator : IMoneyValidator
    {
        public bool IsValid(Money amount)
        {
            return  !IsAmountZero(amount) && 
                    !IsAmountNegative(amount) && 
                    IsCentsValid(amount) &&
                    IsAmountValid(amount);
        }

        private bool IsAmountZero(Money amount)
        {
            if (amount.Cents == 0 && amount.Euros == 0)
            {
                return true;
            }
            
            return false;
        }

        private bool IsAmountNegative(Money amount)
        {
            if (amount.Cents < 0 || amount.Euros < 0)
            {
                return true;
            }
            
            return false;
        }

        private bool IsAmountValid(Money amount)
        {
            bool validEuro = Enum.IsDefined(typeof(EnumEuro), amount.Euros);
            bool validCent = Enum.IsDefined(typeof(EnumCent), amount.Cents);

            if (validEuro && validCent)
            {
                return true;
            }
            
            return false;
        }

        private bool IsCentsValid(Money amount)
        {
            return amount.Cents <= 99;
        }
    }
}
