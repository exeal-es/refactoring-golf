using System.Collections.Generic;
using System.Linq;

namespace Hole6
{
    public class TakeHomeCalculator
    {
        private readonly TaxRate taxRate;

        public TakeHomeCalculator(TaxRate taxRate)
        {
            this.taxRate = taxRate;
        }

        public Money NetAmount(Money first, params Money[] rest)
        {
            Money total = rest.Aggregate(first, (current, x) => current.Plus(x));
            Money tax = taxRate.Apply(total);
            return total.Minus(tax);
        }
    }
}