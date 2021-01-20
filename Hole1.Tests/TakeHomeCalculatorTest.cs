using System;
using Xunit;

namespace Hole1.Tests
{
    public class TakeHomeCalculatorTest
    {
        [Fact]
        public void CanCalculateTax()
        {
            int first = new TakeHomeCalculator(10).NetAmount(new Pair<int, String>(40, "GBP"),
                new Pair<int, String>(50, "GBP"),
                new Pair<int, String>(60, "GBP")).first;
            Assert.Equal(135, first);
        }

        [Fact]
        public void CannotSumDifferentCurrencies()
        {
            Assert.Throws<Incalculable>(() => new TakeHomeCalculator(10).NetAmount(new
                Pair<int, String>(4, "GBP"), new Pair<int, String>(5, "USD")));
        }
    }
}