using Xunit;

namespace Hole2.Tests
{
    public class TakeHomeCalculatorTest
    {
        [Fact]
        public void CanCalculateTax()
        {
            int first = new TakeHomeCalculator(10).NetAmount(new Pair<string>(40, "GBP"),
                new Pair<string>(50, "GBP"),
                new Pair<string>(60, "GBP")).first;
            Assert.Equal(135, first);
        }

        [Fact]
        public void CannotSumDifferentCurrencies()
        {
            Assert.Throws<Incalculable>(() => new TakeHomeCalculator(10).NetAmount(new
                Pair<string>(4, "GBP"), new Pair<string>(5, "USD")));
        }
    }
}