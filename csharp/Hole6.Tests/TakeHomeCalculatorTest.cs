using System;
using Xunit;

namespace Hole6.Tests
{
    public class TakeHomeCalculatorTest
    {
        [Fact]
        public void CanCalculateTax()
        {
            int first = new TakeHomeCalculator(TaxRate.Of(10)).NetAmount(Money.Create(40, "GBP"),
                Money.Create(50, "GBP"),
                Money.Create(60, "GBP")).value;
            Assert.Equal(135, first);
        }

        [Fact]
        public void CannotSumDifferentCurrencies()
        {
            Assert.Throws<Incalculable>(() => new TakeHomeCalculator(TaxRate.Of(10)).NetAmount(
                Money.Create(4, "GBP"), Money.Create(5, "USD")));
        }
    }
}