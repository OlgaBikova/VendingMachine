using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class SimpleVendingMachine : IVendingMachine
    {
        private string manufacturer = "Vending machine";

        public string Manufacturer
        {
            get { return this.manufacturer; }
        }

        public Money Amount
        {
            get { throw new NotImplementedException(); }
        }

        public Product[] Products
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Money InsertCoin(Money amount)
        {
            throw new NotImplementedException();
        }

        public Money ReturnMoney()
        {
            throw new NotImplementedException();
        }

        public Product Buy(int productNumber)
        {
            throw new NotImplementedException();
        }
    }
}
