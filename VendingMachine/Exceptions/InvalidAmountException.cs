using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace VendingMachine.Exceptions
{
    [Serializable]
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
