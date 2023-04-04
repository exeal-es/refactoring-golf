using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole3
{
    public class TakeHomeCalculator
    {
        private readonly int percent;

        public TakeHomeCalculator(int percent)
        {
            this.percent = percent;
        }

        public Money NetAmount(Money first, params Money[] rest)
        {
            List<Money> monies = rest.ToList();

            Money total = first;

            foreach (Money next in monies)
            {
                total = Plus(next, total);
            }

            Double amount = total.value * (percent / 100d);
            Money tax = new Money(Convert.ToInt32(amount), first.currency);

            if (!total.currency.Equals(tax.currency))
            {
                throw new Incalculable();
            }

            return new Money(total.value - tax.value, first.currency);
        }

        private static Money Plus(Money next, Money total)
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