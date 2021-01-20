using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole5
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
                total = total.Plus(next);
            }

            Double amount = total.value * (percent / 100d);
            Money tax = Money.Create(Convert.ToInt32(amount), first.currency);

            return total.Minus(tax);
        }
    }
}