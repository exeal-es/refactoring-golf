using Xunit;

namespace Hole2.Tests
{
    public class TakeHomeCalculatorTest
    {
        [Fact]
        public void CanCalculateTax()
        {
            int first = new TakeHomeCalculator(10).NetAmount(new Pair(40, "GBP"),
                new Pair(50, "GBP"),
                new Pair(60, "GBP")).value;
            Assert.Equal(135, first);
        }

        [Fact]
        public void CannotSumDifferentCurrencies()
        {
            Assert.Throws<Incalculable>(() => new TakeHomeCalculator(10).NetAmount(new
                Pair(4, "GBP"), new Pair(5, "USD")));
        }
    }
}