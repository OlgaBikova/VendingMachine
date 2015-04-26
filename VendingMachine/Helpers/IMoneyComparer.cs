using System.Collections.Generic;

namespace VendingMachine
{
    public interface IMoneyComparer : IComparer<Money>
    {
        int Compare(Money amount, Money productPrice);
    }
}
