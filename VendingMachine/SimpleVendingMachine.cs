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
        private Money money = new Money();

        private IMoneyValidator moneyValidator;

        public SimpleVendingMachine(IMoneyValidator moneyValidator)
        {
            this.moneyValidator = moneyValidator;
        }

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
            if (moneyValidator.IsAmountZero(amount))
            {
                throw new InvalidAmountException("Cannot insert zero money");   
            }

            if (moneyValidator.IsAmountNegative(amount))
            {
                throw new InvalidAmountException("Cannot insert negative amount of money");  
            }


            return new Money();
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
