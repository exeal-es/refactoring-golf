using System;

namespace Hole5
{
    public class TaxRate
    {
        private readonly int _percent;

        private TaxRate(int percent)
        {
            _percent = percent;
        }

        public static TaxRate Of(int percent)
        {
            return new TaxRate(percent);
        }

        public Money Apply(Money first, Money total)
        {
            Double amount = total.value * (_percent / 100d);
            return Money.Create(Convert.ToInt32(amount), first.currency);
        }
    }
}