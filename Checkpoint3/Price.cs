namespace Checkpoint3
{
    internal enum Currency { SEK, USD, EUR }
    internal class Price
    {
        public decimal Amount { get; }
        public Currency Currency { get; }
        public Price(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
