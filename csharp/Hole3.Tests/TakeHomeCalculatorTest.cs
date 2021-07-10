using System;
using Xunit;

namespace Hole3.Tests
{
    public class TakeHomeCalculatorTest
    {
        [Fact]
        public void CanCalculateTax()
        {
            int first = new TakeHomeCalculator(10).NetAmount(new Money(40, "GBP"),
                new Money(50, "GBP"),
                new Money(60, "GBP")).value;
            Assert.Equal(135, first);
        }

        [Fact]
        public void CannotSumDifferentCurrencies()
        {
            Assert.Throws<Incalculable>(() => new TakeHomeCalculator(10).NetAmount(new
                Money(4, "GBP"), new Money(5, "USD")));
        }
    }
}