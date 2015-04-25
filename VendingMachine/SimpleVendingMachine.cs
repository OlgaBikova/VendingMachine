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
            get { return this.money; }
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
            if (moneyValidator.IsValid(amount))
            {
                throw new InvalidAmountException("Invalid amount received", amount);   
            }

            this.money.Cents += amount.Cents;
            this.money.Euros += amount.Euros;
            
            return this.money;
        }

        public Money ReturnMoney()
        {
            Money returnedMoney = this.money;
            this.money.Euros = (int)EnumEuro.ZeroEuro;
            this.money.Cents = (int)EnumCent.ZeroCent;

            return returnedMoney;
        }

        public Product Buy(int productNumber)
        {
            throw new NotImplementedException();
        }
    }
}
