using System;

namespace VendingMachine
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException()
        {
        }

        public NotEnoughMoneyException(string message)
            : base(message)
        {
        }

        public NotEnoughMoneyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
