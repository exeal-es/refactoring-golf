using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole4
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
            var firstCurrency = first.currency;
            Money tax = Money.Create(amount, firstCurrency);

            return Money.Minus(total, tax);
        }
    }
}