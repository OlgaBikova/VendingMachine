using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Helpers
{
    public interface IMoneyCalculation
    {
        Money Add(Money amount, Money currentMoney);

        Money Subtract(Money amount, Money currentMoney);
    }
}
