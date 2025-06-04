namespace Checkpoint3
{
    internal class Computer : Asset
    {
        public override string Type { get; } = "Computer";
        public Computer(Price price, DateTime purchaseDate, string brand, string model, Office office) : base(price, purchaseDate, brand, model, office)
        {
        }
    }
}
