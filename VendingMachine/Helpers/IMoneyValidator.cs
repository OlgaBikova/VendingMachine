using System;

namespace VendingMachine
{
    public interface IMoneyValidator
    {
        bool IsValid(Money amount);
    }
}
