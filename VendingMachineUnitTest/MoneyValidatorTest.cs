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
            //insert -1 cent
            Money negativeMoney1 = new Money();
            negativeMoney1.Cents = -1;

            //insert -1 euro
            Money negativeMoney2 = new Money();
            negativeMoney2.Euros = -1;

            //insert -1 euro and -1 cent
            Money negativeMoney3 = new Money();
            negativeMoney3.Cents = -1;
            negativeMoney3.Euros = -1;

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
            Money notValidMoney1 = new Money();
            notValidMoney1.Cents = 3;

            Money notValidMoney2 = new Money();
            notValidMoney2.Euros = 5;

            bool result1 = moneyValidator.IsValid(notValidMoney1);
            bool result2 = moneyValidator.IsValid(notValidMoney2);

            Assert.AreEqual(false, result1);
            Assert.AreEqual(false, result2);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenAmountIsValid()
        {
            Money fiveCents = new Money();
            fiveCents.Cents = (int)EnumCent.FiveCent;

            Money tenCents = new Money();
            tenCents.Cents = (int)EnumCent.TenCent;

            Money twentyCents = new Money();
            twentyCents.Cents = (int)EnumCent.TwentyCent;

            Money fiftyCents = new Money();
            fiftyCents.Cents = (int)EnumCent.FiftyCent;

            Money oneEuro = new Money();
            oneEuro.Euros = (int)EnumEuro.OneEuro;
            
            Money twoEuros = new Money();
            twoEuros.Euros = (int)EnumEuro.TwoEuro;

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
    }
}
