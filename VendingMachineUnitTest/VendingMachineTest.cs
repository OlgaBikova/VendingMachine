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
        [ExpectedException(typeof(InvalidAmountException), "Invalid amount received")]
        public void ShouldThrowExceptionWhenInsertingInvalidAmount()
        {
            Money zero = new Money();
            moneyValidatorMock.Setup(validator => validator.IsValid(zero)).Returns(true);
            vendingMachine.InsertCoin(zero);
        }

        [TestMethod]
        public void ShoudThrowExceptionWhenInsertingWrongCoins()
        { 
        
        }
    
    }
}
