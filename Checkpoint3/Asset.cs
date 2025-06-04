namespace Checkpoint3
{
    internal abstract class Asset
    {
        abstract public string Type { get; }
        public string Brand { get; }
        public string Model { get; }
        public Price Price { get; }
        public DateTime PurchaseDate { get; }
        public Office Office { get; }

        public Asset(Price price, DateTime purchaseDate, string brand, string model, Office office)
        {
            Price = price;
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Office = office;
        }
    }
}