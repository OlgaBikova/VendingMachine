using System;
using Moq;
using System.Linq;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace VendingMachineUnitTest
{
    [TestClass]
    public class VendingMachineTest
    {
        Mock<IMoneyValidator> moneyValidatorMock = new Mock<IMoneyValidator>();
        SimpleVendingMachine vendingMachine;

        [TestInitialize]
        public void init()
        {
            vendingMachine = new SimpleVendingMachine(moneyValidatorMock.Object);
        }

        [TestMethod]
        public void ShouldReturnManufacturer()
        {
            Assert.AreEqual("Vending machine", vendingMachine.Manufacturer);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAmountException), "Invalid amount received")]
        public void ShouldThrowExceptionWhenInsertingInvalidAmount()
        {
            Money zero = new Money();
            moneyValidatorMock.Setup(validator => validator.IsValid(zero)).Returns(true);
            vendingMachine.InsertCoin(zero);
        }

        [TestMethod]
        public void ShoudReturnSummedAmountWhenInsertingCoins()
        {
            Money fiveCents = new Money() { Cents = (int)EnumCent.FiveCent };
            Money twoEuros = new Money() { Euros = (int)EnumEuro.TwoEuro };

            Money result1 = vendingMachine.InsertCoin(fiveCents);

            Assert.AreEqual((int)EnumCent.FiveCent, result1.Cents);
            Assert.AreEqual((int)EnumEuro.ZeroEuro, result1.Euros);
            Assert.AreEqual(result1, vendingMachine.Amount);

            Money result2 = vendingMachine.InsertCoin(twoEuros);

            Assert.AreEqual((int)EnumCent.FiveCent, result2.Cents);
            Assert.AreEqual((int)EnumEuro.TwoEuro, result2.Euros);
            Assert.AreEqual(result2, vendingMachine.Amount);
        }

        [TestMethod]
        public void ShouldReturnCurrentMoneyAndSetAmountToZero()
        { 
            //insert coin
            Money money = new Money() { Euros = (int)EnumEuro.TwoEuro };
    
            vendingMachine.InsertCoin(money);

            //call ReturnMoney
            Money returnedAmount = vendingMachine.ReturnMoney();            

            //verify returned money are equal to inserted money
            Assert.AreEqual(money.Euros, returnedAmount.Euros);
            Assert.AreEqual(money.Cents, returnedAmount.Cents);
            //verify amount is zero
            Assert.AreEqual((int)EnumEuro.ZeroEuro, vendingMachine.Amount.Euros);
            Assert.AreEqual((int)EnumCent.ZeroCent, vendingMachine.Amount.Cents);
        }

        [TestMethod]
        public void ShouldSetAndReturnProducts()
        {
            IList<Product> productList = new List<Product>();
            Product product1 = new Product()
            {
                Available = 1,
                Name = "Product1",
                Price = new Money() { Cents = 75 }
            };
            
            Product product2 = new Product()
            {
                Available = 2,
                Name = "Product2",
                Price = new Money() { Euros = 1, Cents = 25 }
            };

            productList.Add(product1);
            productList.Add(product2);

            vendingMachine.Products = productList.ToArray();

            Product[] settedProducts = vendingMachine.Products;

            Assert.AreEqual(2, settedProducts.Count());
            Assert.IsTrue(settedProducts.Any(product => product.Name == "Product1"));
            Assert.IsTrue(settedProducts.Any(product => product.Name == "Product2"));
        }

        [TestMethod]
        [ExpectedException(typeof(ProductDoesNotExistException), "Product does not exist for number 2")]
        public void ShouldThrowExceptionWhenProductDoesNotExist()
        {
            vendingMachine.Buy(2);
        }
    }
}
