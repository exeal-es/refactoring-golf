using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole5
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
            Money tax = Money.Create(Convert.ToInt32(amount), first.currency);

            return total.Minus(tax);
        }

        public class Money {
            public readonly int value;
            public readonly String currency;

            private Money(int value, String currency) {
                this.value = value;
                this.currency = currency;
            }
            
            public static Money Create(int value, String currency) {
                return new Money(value, currency);
            }

            public Money Plus(Money other) {
                if (!other.currency.Equals(currency)) {
                    throw new Incalculable();
                }
                return Create(value + other.value, other.currency);
            }
            
            public Money Minus(Money other) {
                if (!currency.Equals(other.currency)) {
                    throw new Incalculable();
                }
                return Create(value - other.value, currency);
            }
        }
    }
    
    public class Incalculable : Exception {

    }
}