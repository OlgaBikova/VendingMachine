using System;

namespace VendingMachine
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
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
