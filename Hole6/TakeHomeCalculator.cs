using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole6
{
    public class TakeHomeCalculator {

        private readonly TaxRate taxRate;

        public TakeHomeCalculator(TaxRate taxRate) {
            this.taxRate = taxRate;
        }

        public Money NetAmount(Money first, params Money[] rest) {

            List<Money> monies = rest.ToList();

            Money total = first;

            foreach (Money next in monies) {
                total = total.Plus(next);
            }

            Money tax = taxRate.Apply(total);
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
        
        public class TaxRate {
            private readonly int percent;

            private TaxRate(int percent) {
                this.percent = percent;
            }

            public static TaxRate Of(int percent) {
                return new TaxRate(percent);
            }

            public int GetPercent() {
                return percent;
            }

            public Money Apply(Money total) {
                Double amount = total.value * (GetPercent() / 100d);
                return Money.Create(Convert.ToInt32(amount), total.currency);
            }
        }
    }
    
    public class Incalculable : Exception {

    }
}