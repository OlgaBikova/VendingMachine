﻿using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Exceptions;
using VendingMachine.Helpers;

namespace VendingMachine
{
    public class SimpleVendingMachine : IVendingMachine
    {
        private string manufacturer = "Vending machine";
        private Money money = new Money();
        private IList<Product> products = new List<Product>();

        private IMoneyValidator moneyValidator;
        private IMoneyComparer moneyComparer;
        private IMoneyCalculation moneyCalculation;

        public SimpleVendingMachine(IMoneyValidator moneyValidator, IMoneyComparer moneyComparer, IMoneyCalculation moneyCalculation)
        {
            this.moneyValidator = moneyValidator;
            this.moneyComparer = moneyComparer;
            this.moneyCalculation = moneyCalculation;
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
                return this.products.ToArray();
            }
            set
            {
                this.products = new List<Product>(value);
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
            Product product;

            try
            {
                product = products[productNumber];
            }
            catch (ArgumentOutOfRangeException)
            { 
                throw new ProductDoesNotExistException("Product does not exist for number " + productNumber);
            }

            Money productPrice = product.Price;

            int moneyCompareResult = moneyComparer.Compare(Amount, productPrice);

            if (moneyCompareResult < 0)
            {
                throw new NotEnoughMoneyException("Not enough money for product " + productNumber);
            }

            Money remainder = moneyCalculation.Subtract(productPrice, Amount);
            
            this.money = remainder;

            return product;
        }
    }
}
