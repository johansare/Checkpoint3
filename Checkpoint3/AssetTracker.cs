namespace Checkpoint3
{
    internal class AssetTracker
    {
        private readonly List<Asset> assets;
        private readonly Office sweden;
        private readonly Office germany;
        private readonly Office usa;

        public AssetTracker()
        {
            assets = [];
            sweden = new Office("Sweden", Currency.SEK);
            germany = new Office("Germany", Currency.EUR);
            usa = new Office("USA", Currency.USD);
        }

        public void Demo()
        {
            // adding assets just for fun
            AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 5), "Motorola", "X3", usa));
            AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 10), "Motorola", "X2", usa));
            AddAsset(new Smartphone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 6), "Samsung", "Galaxy 10", sweden));
            AddAsset(new Smartphone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Samsung", "Galaxy 10", sweden));
            AddAsset(new Smartphone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 4), "Sony", "XPeria 7", sweden));
            AddAsset(new Smartphone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 5), "Sony", "XPeria 7", sweden));
            AddAsset(new Smartphone(new Price(220, Currency.EUR), DateTime.Now.AddMonths(-36 + 12), "Siemens", "Brick", germany));
            AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-38), "Dell", "Desktop 900", usa));
            AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-37), "Dell", "Desktop 900", usa));
            AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 1), "Lenovo", "X100", usa));
            AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Lenovo", "X200", usa));
            AddAsset(new Computer(new Price(500, Currency.USD), DateTime.Now.AddMonths(-36 + 9), "Lenovo", "X300", usa));
            AddAsset(new Computer(new Price(1500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Dell", "Optiplex 100", sweden));
            AddAsset(new Computer(new Price(1400, Currency.SEK), DateTime.Now.AddMonths(-36 + 8), "Dell", "Optiplex 200", sweden));
            AddAsset(new Computer(new Price(1300, Currency.SEK), DateTime.Now.AddMonths(-36 + 9), "Dell", "Optiplex 300", sweden));
            AddAsset(new Computer(new Price(1600, Currency.EUR), DateTime.Now.AddMonths(-36 + 14), "Asus", "ROG 600", germany));
            AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 4), "Asus", "ROG 500", germany));
            AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 3), "Asus", "ROG 500", germany));
            AddAsset(new Computer(new Price(1300, Currency.EUR), DateTime.Now.AddMonths(-36 + 2), "Asus", "ROG 500", germany));

            PrintData();
        }

        public void AddAsset(Asset asset)
        {
            assets.Add(asset);
        }

        public void PrintData()
        {
            if (assets.Count <= 0)
            {
                Console.WriteLine("No asset in database.");
                return;
            }

            ColorWriteLine("Office".PadRight(15) + "Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Purchase Date".PadRight(15) + "Price (local)".PadRight(15) + "Price (USD)".PadRight(15), ConsoleColor.DarkGray);

            foreach (Asset asset in assets.OrderBy(asset => asset.Office.Location).ThenBy(asset => asset.PurchaseDate))
            {
                ConsoleColor colorMark = Console.ForegroundColor;

                TimeSpan timeSincePurchase = DateTime.Now - asset.PurchaseDate;
                TimeSpan threeYearsMinusThreeMounth = TimeSpan.FromDays(365 * 3 - 30 * 3);
                TimeSpan threeYearsMinusSixMounth = TimeSpan.FromDays(365 * 3 - 30 * 6);

                if (timeSincePurchase > threeYearsMinusThreeMounth)
                    colorMark = ConsoleColor.Red;
                else if (timeSincePurchase > threeYearsMinusSixMounth)
                    colorMark = ConsoleColor.Yellow;

                ColorWrite(asset.Office.Location.PadRight(15), colorMark);
                ColorWrite(asset.Type.PadRight(15), colorMark);
                ColorWrite(asset.Brand.PadRight(15), colorMark);
                ColorWrite(asset.Model.PadRight(15), colorMark);
                ColorWrite(asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(15), colorMark);
                ColorWrite($"{asset.Price.Currency} {asset.Price.Amount}".PadRight(15), colorMark);
                ColorWrite($"{CurrencyConverter.Convert(asset.Price.Amount, asset.Price.Currency, Currency.USD):F2}", colorMark);
                Console.WriteLine();
            }
        }

        private void ColorWrite(string s, ConsoleColor c)
        {
            ConsoleColor save = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.Write(s);
            Console.ForegroundColor = save;
        }

        private void ColorWriteLine(string s, ConsoleColor c)
        {
            ConsoleColor save = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.WriteLine(s);
            Console.ForegroundColor = save;
        }
    }
}