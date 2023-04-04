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
            Money tax = Create(amount, firstCurrency);

            return Minus(total, tax);
        }

        private static Money Minus(Money total, Money tax)
        {
            string firstCurrency;
            if (!total.currency.Equals(tax.currency))
            {
                throw new Incalculable();
            }

            return new Money(total.value - tax.value, firstCurrency);
        }

        private static Money Create(double amount, string currency)
        {
            return new Money(Convert.ToInt32(amount), currency);
        }
    }
}