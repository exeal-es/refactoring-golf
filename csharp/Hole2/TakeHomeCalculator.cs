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

        public Pair<string> NetAmount(Pair<string> first, params Pair<string>[] rest)
        {
            List<Pair<string>> pairs = rest.ToList();

            Pair<string> total = first;

            foreach (Pair<string> next in pairs)
            {
                if (!next.second.Equals(total.second))
                {
                    throw new Incalculable();
                }
            }

            foreach (Pair<string> next in pairs)
            {
                total = new Pair<string>(total.first + next.first, next.second);
            }

            Double amount = total.first * (percent / 100d);
            Pair<string> tax = new Pair<string>(Convert.ToInt32(amount), first.second);

            if (!total.second.Equals(tax.second))
            {
                throw new Incalculable();
            }

            return new Pair<string>(total.first - tax.first, first.second);
        }
    }
}