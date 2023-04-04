using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole2
{
    public class TakeHomeCalculator
    {
        private readonly int percent;

        public TakeHomeCalculator(int percent)
        {
            this.percent = percent;
        }

        public Pair NetAmount(Pair first, params Pair[] rest)
        {
            List<Pair> pairs = rest.ToList();

            Pair total = first;

            foreach (Pair next in pairs)
            {
                if (!next.currency.Equals(total.currency))
                {
                    throw new Incalculable();
                }
            }

            foreach (Pair next in pairs)
            {
                total = new Pair(total.value + next.value, next.currency);
            }

            Double amount = total.value * (percent / 100d);
            Pair tax = new Pair(Convert.ToInt32(amount), first.currency);

            if (!total.currency.Equals(tax.currency))
            {
                throw new Incalculable();
            }

            return new Pair(total.value - tax.value, first.currency);
        }
    }
}