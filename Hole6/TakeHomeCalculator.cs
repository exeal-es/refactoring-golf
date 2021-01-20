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
            List<Money> monies = rest.ToList();

            Money total = first;

            foreach (Money next in monies)
            {
                total = total.Plus(next);
            }

            Money tax = taxRate.Apply(total);
            return total.Minus(tax);
        }
    }
}