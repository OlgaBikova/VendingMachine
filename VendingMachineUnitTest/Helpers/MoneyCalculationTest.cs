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
    public class MoneyCalculationTest
    {
        private MoneyCalculation moneyCalculation = new MoneyCalculation();

        [TestMethod]
        public void ShoudlReturnSummedMoney()
        {
            Money amount1 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = (int)EnumCent.TwentyCent };
            Money amount2 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = 95 };

            Money result = moneyCalculation.Add(amount2, amount1);

            Assert.AreEqual(3, result.Euros);
            Assert.AreEqual(15, result.Cents);
        }

        [TestMethod]
        public void ShoudlReturnSummedEuros()
        {
            Money amount1 = new Money() { Euros = (int)EnumEuro.OneEuro};
            Money amount2 = new Money() { Euros = 3};

            Money result = moneyCalculation.Add(amount2, amount1);

            Assert.AreEqual(4, result.Euros);
        }

        [TestMethod]
        public void ShoudlReturnSummedCents()
        {
            Money amount1 = new Money() { Cents = (int)EnumCent.TwentyCent };
            Money amount2 = new Money() { Cents = 25 };

            Money result = moneyCalculation.Add(amount2, amount1);

            Assert.AreEqual(45, result.Cents);
        }

        [TestMethod]
        public void ShouldReturnNegativeResultAfterSubtract()
        {
            Money amount1 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = (int)EnumCent.TwentyCent };
            Money amount2 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = 95 };

            Money result = moneyCalculation.Subtract(amount2, amount1);

            Assert.AreEqual(0, result.Euros);
            Assert.AreEqual(-75, result.Cents);
        }

        [TestMethod]
        public void ShouldReturnPositiveResultAfterSubtract()
        {
            Money amount1 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = 25 };
            Money amount2 = new Money() { Euros = (int)EnumEuro.ZeroEuro, Cents = (int)EnumCent.FiftyCent };

            Money result = moneyCalculation.Subtract(amount2, amount1);

            Assert.AreEqual(0, result.Euros);
            Assert.AreEqual(75, result.Cents);
        }
    }
}
