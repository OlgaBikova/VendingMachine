using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachineUnitTest
{
    [TestClass]
    public class MoneyUnitTest
    {
        [TestMethod]
        public void ShoudlReturnSummedMoney()
        {
            Money amount1 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = (int)EnumCent.TwentyCent };
            Money amount2 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = 95 };
            
            amount1.Add(amount2);

            Assert.AreEqual(3, amount1.Euros);
            Assert.AreEqual(15, amount1.Cents);
        }

        [TestMethod]
        public void ShoudlReturnSummedEuros()
        {
            Money amount1 = new Money() { Euros = (int)EnumEuro.OneEuro};
            Money amount2 = new Money() { Euros = 3};

            amount1.Add(amount2);

            Assert.AreEqual(4, amount1.Euros);
        }

        [TestMethod]
        public void ShoudlReturnSummedCents()
        {
            Money amount1 = new Money() { Cents = (int)EnumCent.TwentyCent };
            Money amount2 = new Money() { Cents = 25 };

            amount1.Add(amount2);

            Assert.AreEqual(45, amount1.Cents);
        }

        [TestMethod]
        public void ShouldReturnNegativeResultAfterSubtract()
        {
            Money amount1 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = (int)EnumCent.TwentyCent };
            Money amount2 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = 95 };

            amount1.Subtract(amount2);

            Assert.AreEqual(0, amount1.Euros);
            Assert.AreEqual(-75, amount1.Cents);
        }

        [TestMethod]
        public void ShouldReturnPositiveResultAfterSubtract()
        {
            Money amount1 = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = 25 };
            Money amount2 = new Money() { Euros = (int)EnumEuro.ZeroEuro, Cents = (int)EnumCent.FiftyCent };
            
            amount1.Subtract(amount2);

            Assert.AreEqual(0, amount1.Euros);
            Assert.AreEqual(75, amount1.Cents);
        }
    }
}
