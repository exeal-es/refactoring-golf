using System;
using Xunit;

namespace Hole4.Tests
{
    public class TakeHomeCalculatorTest
    {
        [Fact]
        public void CanCalculateTax()
        {
            int first = new TakeHomeCalculator(10).NetAmount(new TakeHomeCalculator.Money(40, "GBP"),
                new TakeHomeCalculator.Money(50, "GBP"),
                new TakeHomeCalculator.Money(60, "GBP")).value;
            Assert.Equal(135, first);
        }

        [Fact]
        public void CannotSumDifferentCurrencies()
        {
            Assert.Throws<Incalculable>(() => new TakeHomeCalculator(10).NetAmount(new
                TakeHomeCalculator.Money(4, "GBP"), new TakeHomeCalculator.Money(5, "USD")));
        }
    }
}