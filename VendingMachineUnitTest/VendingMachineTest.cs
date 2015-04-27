using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VendingMachine;
using VendingMachine.Helpers;

namespace VendingMachineUnitTest
{
    [TestClass]
    public class VendingMachineTest
    {
        Mock<IMoneyValidator> moneyValidatorMock = new Mock<IMoneyValidator>();
        Mock<IMoneyComparer> moneyComparer = new Mock<IMoneyComparer>();
        Mock<IMoneyCalculation> moneyCalculation = new Mock<IMoneyCalculation>();
        SimpleVendingMachine vendingMachine;

        [TestInitialize]
        public void init()
        {
            vendingMachine = new SimpleVendingMachine(moneyValidatorMock.Object, moneyComparer.Object, moneyCalculation.Object);
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
            Money money = new Money() { Euros = (int)EnumEuro.TwoEuro };
            vendingMachine.InsertCoin(money);

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

        [TestMethod]
        [ExpectedException(typeof(NotEnoughMoneyException), "Not enough money for product 1")]
        public void ShoudlThrowExceptionWhenNotEnoughMoney()    
        {
            IList<Product> productList = new List<Product>();
            Product product1 = new Product()
            {
                Available = 1,
                Name = "Product1",
                Price = new Money() { Cents = 75 }
            };

            productList.Add(product1);

            vendingMachine.Products = productList.ToArray();

            Money fiveCents = new Money() { Cents = (int)EnumCent.FiveCent };
            vendingMachine.InsertCoin(fiveCents);

            moneyComparer.Setup(comparer => comparer.Compare(fiveCents, product1.Price)).Returns(-1);

            //buy first product
            vendingMachine.Buy(0);
        }

        [TestMethod]
        public void ShouldReturnBoughtProduct()
        {
            IList<Product> productList = new List<Product>();
            Product product1 = new Product()
            {
                Available = 1,
                Name = "Product1",
                Price = new Money() { Cents = 75 }
            };

            productList.Add(product1);

            vendingMachine.Products = productList.ToArray();

            Money fiveCents = new Money() { Cents = (int)EnumCent.FiveCent };
            Money OneEuro = new Money() { Euros = (int)EnumEuro.OneEuro };

            vendingMachine.InsertCoin(fiveCents);
            vendingMachine.InsertCoin(OneEuro);

            Money remainder = new Money() { Cents = 30 };
            moneyCalculation.Setup(calculation => calculation.Subtract(product1.Price, vendingMachine.Amount)).Returns(remainder);

            Product bougthProduct = vendingMachine.Buy(productList.IndexOf(product1));

            Assert.AreEqual(product1, bougthProduct);
            Assert.AreEqual(0, vendingMachine.Amount.Euros);
            Assert.AreEqual(30, vendingMachine.Amount.Cents);
        }
    }
}
