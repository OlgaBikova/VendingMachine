using System;
using Moq;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineUnitTest
{
    [TestClass]
    public class VendingMachineTest
    {
        Mock<IMoneyValidator> moneyValidatorMock = new Mock<IMoneyValidator>();
        private SimpleVendingMachine vendingMachine;

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
        [ExpectedException(typeof(InvalidAmountException),"Cannot insert zero money")]
        public void ShouldThrowExceptionWhenInsertingZero()
        {
            Money zero = new Money();
            moneyValidatorMock.Setup(validator => validator.IsAmountZero(zero)).Returns(true);
            vendingMachine.InsertCoin(zero);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAmountException), "Cannot insert negative amount of money")]
        public void ShouldThrowExceptionWhenInsertingNegative()
        {
            Money negativeAmount = new Money();
            moneyValidatorMock.Setup(validator => validator.IsAmountNegative(negativeAmount)).Returns(true);
            vendingMachine.InsertCoin(negativeAmount);
        }

        [TestMethod]
        public void ShoudThrowExceptionWhenInsertingWrongCoins()
        { 
        
        }
    
    }
}
