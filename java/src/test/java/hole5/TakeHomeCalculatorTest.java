package hole5;

import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class TakeHomeCalculatorTest {

    @Test
    public void canCalculateTax() throws Exception {
        Integer first =
                new TakeHomeCalculator(10)
                        .netAmount(
                                Money.money(40, "GBP"),
                                Money.money(50, "GBP"),
                                Money.money(60, "GBP"))
                        .value;
        assertThat(first.intValue()).isEqualTo(135);
    }

    @Test
    public void cannotSumDifferentCurrencies() throws Exception {
        assertThrows(
                Incalculable.class,
                () -> {
                    new TakeHomeCalculator(10)
                            .netAmount(
                                    Money.money(4, "GBP"), Money.money(5, "USD"));
                });
    }
}
