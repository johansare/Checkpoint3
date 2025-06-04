namespace Checkpoint3
{
    // did not get the provided currency converter code to work.
    internal class CurrencyConverter
    {
        public static decimal Convert(decimal input, Currency fromCurrency, Currency toCurrency)
        {
            switch (fromCurrency)
            {
                case Currency.USD:
                    return input;
                case Currency.EUR:
                    return input * 1.1422873M;
                case Currency.SEK:
                    return input * 0.10443485M;
                default:
                    return 1337;
            }
        }
    }
}
