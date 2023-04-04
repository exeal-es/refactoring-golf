using System;

namespace Hole4
{
    public class Money
    {
        public readonly int value;
        public readonly String currency;

        public Money(int value, String currency)
        {
            this.value = value;
            this.currency = currency;
        }

        public Money Plus(Money other)
        {
            if (!other.currency.Equals(currency))
            {
                throw new Incalculable();
            }

            return new Money(value + other.value, other.currency);
        }

        public static Money Minus(Money total, Money tax)
        {
            string firstCurrency;
            if (!total.currency.Equals(tax.currency))
            {
                throw new Incalculable();
            }

            return new Money(total.value - tax.value, currency);
        }

        public static Money Create(double amount, string currency)
        {
            return new Money(Convert.ToInt32(amount), currency);
        }
    }
}