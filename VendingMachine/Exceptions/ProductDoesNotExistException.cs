using System;

namespace VendingMachine
{
    [Serializable]
    public class ProductDoesNotExistException : Exception
    {
        public ProductDoesNotExistException()
        {
        }

        public ProductDoesNotExistException(string message)
            : base(message)
        {
        }

        public ProductDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
