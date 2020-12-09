using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole4
{
    public class TakeHomeCalculator {

        private readonly int percent;

        public TakeHomeCalculator(int percent) {
            this.percent = percent;
        }

        public Money NetAmount(Money first, params Money[] rest) {

            List<Money> monies = rest.ToList();

            Money total = first;

            foreach (Money next in monies) {
                total = total.Plus(next);
            }

            Double amount = total.value * (percent / 100d);
            Money tax = new Money(Convert.ToInt32(amount), first.currency);

            if (!total.currency.Equals(tax.currency)) {
                throw new Incalculable();
            }
            return new Money(total.value - tax.value, first.currency);
        }

        public class Money {
            public readonly int value;
            public readonly String currency;

            public Money(int value, String currency) {
                this.value = value;
                this.currency = currency;
            }

            public Money Plus(Money other) {
                if (!other.currency.Equals(currency)) {
                    throw new Incalculable();
                }
                return new Money(value + other.value, other.currency);
            }
        }
    }
    
    public class Incalculable : Exception {

    }
}