using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
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
