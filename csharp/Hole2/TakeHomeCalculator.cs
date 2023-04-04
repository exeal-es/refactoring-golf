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
                if (!next.second.Equals(total.second))
                {
                    throw new Incalculable();
                }
            }

            foreach (Pair next in pairs)
            {
                total = new Pair(total.first + next.first, next.second);
            }

            Double amount = total.first * (percent / 100d);
            Pair tax = new Pair(Convert.ToInt32(amount), first.second);

            if (!total.second.Equals(tax.second))
            {
                throw new Incalculable();
            }

            return new Pair(total.first - tax.first, first.second);
        }
    }
}