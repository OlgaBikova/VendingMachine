using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IMoneyComparer : IComparer<Money>
    {
        int Compare(Money amount, Money productPrice);
    }
}
