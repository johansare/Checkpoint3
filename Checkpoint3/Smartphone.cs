namespace Checkpoint3
{
    internal class Smartphone : Asset
    {
        public override string Type { get; } = "Smartphone";
        public Smartphone(Price price, DateTime purchaseDate, string brand, string model, Office office) : base(price, purchaseDate, brand, model, office)
        {
        }
    }
}
