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
        public void ShouldReturnTrueWhenAmountIsZero()
        {
            Money zeroMoney = new Money();
            
            bool result = moneyValidator.IsAmountZero(zeroMoney);
            
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenAmountIsNotZero()
        {
            Money zeroMoney = new Money();
            zeroMoney.Cents = 1;
            zeroMoney.Euros = 1;

            bool result = moneyValidator.IsAmountZero(zeroMoney);

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

            bool result1 = moneyValidator.IsAmountNegative(negativeMoney1);
            bool result2 = moneyValidator.IsAmountNegative(negativeMoney2);
            bool result3 = moneyValidator.IsAmountNegative(negativeMoney3);

            Assert.AreEqual(true, result1);
            Assert.AreEqual(true, result2);
            Assert.AreEqual(true, result3);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenAmountIsNotNegative()
        {
            //insert 1 cent
            Money negativeMoney1 = new Money();
            negativeMoney1.Cents = 1;

            //insert 1 euro
            Money negativeMoney2 = new Money();
            negativeMoney2.Euros = 1;

            //insert 1 euro and 1 cent
            Money negativeMoney3 = new Money();
            negativeMoney3.Cents = 1;
            negativeMoney3.Euros = 1;

            bool result1 = moneyValidator.IsAmountNegative(negativeMoney1);
            bool result2 = moneyValidator.IsAmountNegative(negativeMoney2);
            bool result3 = moneyValidator.IsAmountNegative(negativeMoney3);

            Assert.AreEqual(false, result1);
            Assert.AreEqual(false, result2);
            Assert.AreEqual(false, result3);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenAmountIsNotValid()
        {
            Money invalidMoney1 = new Money();
            invalidMoney1.Cents = 3;

            Money invalidMoney2 = new Money();
            invalidMoney2.Euros = 5;

            bool result1 = moneyValidator.IsAmountValid(invalidMoney1);
            bool result2 = moneyValidator.IsAmountValid(invalidMoney2);

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
            
            bool result1 = moneyValidator.IsAmountValid(fiveCents);
            bool result2 = moneyValidator.IsAmountValid(tenCents);
            bool result3 = moneyValidator.IsAmountValid(twentyCents);
            bool result4 = moneyValidator.IsAmountValid(fiftyCents);
            bool result5 = moneyValidator.IsAmountValid(oneEuro);
            bool result6 = moneyValidator.IsAmountValid(twoEuros);

            Assert.AreEqual(true, result1);
            Assert.AreEqual(true, result2);
            Assert.AreEqual(true, result3);
            Assert.AreEqual(true, result4);
            Assert.AreEqual(true, result5);
            Assert.AreEqual(true, result6);
        }
    }
}
