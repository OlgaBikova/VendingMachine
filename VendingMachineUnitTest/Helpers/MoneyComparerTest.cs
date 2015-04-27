using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;
using VendingMachine.Helpers;

namespace VendingMachineUnitTest
{
    [TestClass]
    public class MoneyComparerTest
    {
        MoneyComparer moneyComparer = new MoneyComparer();

        [TestMethod]
        public void ShouldReturnZeroIfEquals()
        {
            Money amount = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = (int)EnumCent.TenCent };
            Money productPrice = amount;

            Assert.AreEqual(0, moneyComparer.Compare(amount, productPrice));
        }

        [TestMethod]
        public void ShouldReturnNegativeIfAmountLessThenPrice()
        {
            Money amount = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = (int)EnumCent.TenCent };
            Money productPrice = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = (int)EnumCent.TwentyCent };

            Assert.IsTrue(0 > moneyComparer.Compare(amount, productPrice));
        }

        [TestMethod]
        public void ShouldReturnPositiveIfAmountBiggerThenPrice()
        {
            Money amount = new Money() { Euros = (int)EnumEuro.TwoEuro, Cents = (int)EnumCent.TwentyCent };
            Money productPrice = new Money() { Euros = (int)EnumEuro.OneEuro, Cents = (int)EnumCent.TwentyCent };

            Assert.IsTrue(0 < moneyComparer.Compare(amount, productPrice));
        }
    }
}
