using System;

namespace VendingMachine
{
    public struct Money
    {
        public int Euros { get; set; }
        public int Cents { get; set; }

        public void Add(Money amount)
        {
            int amountCents = this.ConvertToCent(amount);
            int currentCents = this.ConvertToCent(this);

            int sumCents = currentCents + amountCents;

            this.Euros = sumCents / 100;
            this.Cents = sumCents % 100;
        }

        public void Subtract(Money amount)
        {
            int amountCents = this.ConvertToCent(amount);
            int currentCents = this.ConvertToCent(this);

            int sumCents = currentCents - amountCents;

            this.Euros = sumCents / 100;
            this.Cents = sumCents % 100;
        }

        private int ConvertToCent(Money amount)
        {
            return amount.Euros * 100 + amount.Cents;
        }
    }
}
