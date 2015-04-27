using System;

namespace VendingMachine.Helpers
{
    public interface IMoneyValidator
    {
        bool IsValid(Money amount);
    }
}
