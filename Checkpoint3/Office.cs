namespace Checkpoint3
{
    class Office
    {
        public string Location { get; }
        public Currency Currency { get; }
        public Office(string location, Currency currency)
        {
            Location = location;
            Currency = currency;
        }
    }
}
