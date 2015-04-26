using System;

namespace VendingMachine
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException()
        {
        }

        public InvalidAmountException(string message)
            : base(message)
        {
        }

        public InvalidAmountException(string message, Money amount)
            : base(message)
        {
        }

        public InvalidAmountException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
