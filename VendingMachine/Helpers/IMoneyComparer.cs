using System.Collections.Generic;

namespace VendingMachine.Helpers
{
    public interface IMoneyComparer : IComparer<Money>
    {
        int Compare(Money amount, Money productPrice);
    }
}
