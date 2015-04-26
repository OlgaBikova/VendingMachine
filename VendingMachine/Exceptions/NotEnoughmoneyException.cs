using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
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
