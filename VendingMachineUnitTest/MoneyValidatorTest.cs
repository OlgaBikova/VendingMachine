using System;
using Moq;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineUnitTest
{
    [TestClass]
    public class MoneyValidatorTest
    {
        private MoneyValidator moneyValidator = new MoneyValidator();

        [TestMethod]
        public void ShouldReturnFalseWhenAmountIsZero()
        {
            Money zeroMoney = new Money();
            
            bool result = moneyValidator.IsValid(zeroMoney);
            
            Assert.AreEqual(false, result);
        }
                
        [TestMethod]
        public void ShouldReturnTrueWhenAmountIsNegative()
        {
            Money negativeMoney1 = new Money() { Cents = -1 };
            Money negativeMoney2 = new Money() { Euros = -1 };
            Money negativeMoney3 = new Money() { Cents = -1, Euros = -1 };

            bool result1 = moneyValidator.IsValid(negativeMoney1);
            bool result2 = moneyValidator.IsValid(negativeMoney2);
            bool result3 = moneyValidator.IsValid(negativeMoney3);

            Assert.AreEqual(false, result1);
            Assert.AreEqual(false, result2);
            Assert.AreEqual(false, result3);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenAmountIsNotValid()
        {
            Money notValidMoney1 = new Money() { Cents = 3 };
            Money notValidMoney2 = new Money() { Euros = 5 };
            
            bool result1 = moneyValidator.IsValid(notValidMoney1);
            bool result2 = moneyValidator.IsValid(notValidMoney2);

            Assert.AreEqual(false, result1);
            Assert.AreEqual(false, result2);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenAmountIsValid()
        {
            Money fiveCents = new Money() { Cents = (int)EnumCent.FiveCent };
            Money tenCents = new Money() { Cents = (int)EnumCent.TenCent };
            Money twentyCents = new Money() { Cents = (int)EnumCent.TwentyCent };
            Money fiftyCents = new Money() { Cents = (int)EnumCent.FiftyCent };
            Money oneEuro = new Money() { Euros = (int)EnumEuro.OneEuro };
            Money twoEuros = new Money() { Euros = (int)EnumEuro.TwoEuro };
            
            bool result1 = moneyValidator.IsValid(fiveCents);
            bool result2 = moneyValidator.IsValid(tenCents);
            bool result3 = moneyValidator.IsValid(twentyCents);
            bool result4 = moneyValidator.IsValid(fiftyCents);
            bool result5 = moneyValidator.IsValid(oneEuro);
            bool result6 = moneyValidator.IsValid(twoEuros);

            Assert.AreEqual(true, result1);
            Assert.AreEqual(true, result2);
            Assert.AreEqual(true, result3);
            Assert.AreEqual(true, result4);
            Assert.AreEqual(true, result5);
            Assert.AreEqual(true, result6);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenCentIsNotValid()
        {
            Money notValidCent = new Money() { Cents = 100 };

            bool result = moneyValidator.IsValid(notValidCent);
            
            Assert.AreEqual(false, result);
        }
    }
}
