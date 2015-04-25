using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IMoneyValidator
    {
        bool IsAmountZero(Money amount);

        bool IsAmountNegative(Money amount);

        bool IsAmountValid(Money amount);
    }
}
