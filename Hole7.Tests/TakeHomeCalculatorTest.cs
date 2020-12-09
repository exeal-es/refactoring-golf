using System;
using Xunit;

namespace Hole7.Tests
{
    public class TakeHomeCalculatorTest
    {
        [Fact]
        public void CanCalculateTax()
        {
            int first = new TakeHomeCalculator(TakeHomeCalculator.TaxRate.Of(10)).NetAmount(TakeHomeCalculator.Money.Create(40, "GBP"),
                TakeHomeCalculator.Money.Create(50, "GBP"),
                TakeHomeCalculator.Money.Create(60, "GBP")).value;
            Assert.Equal(135, first);
        }

        [Fact]
        public void CannotSumDifferentCurrencies()
        {
            Assert.Throws<Incalculable>(() => new TakeHomeCalculator(TakeHomeCalculator.TaxRate.Of(10)).NetAmount(
                TakeHomeCalculator.Money.Create(4, "GBP"), TakeHomeCalculator.Money.Create(5, "USD")));
        }
    }
}