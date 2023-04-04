using System;

namespace Hole3
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

        public static Money Plus(Money next, Money total)
        {
            if (!next.currency.Equals(total.currency))
            {
                throw new Incalculable();
            }

            total = new Money(total.value + next.value, next.currency);
            return total;
        }
    }
}