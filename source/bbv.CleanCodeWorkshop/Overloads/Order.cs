namespace Bbv.CleanCodeWorkshop.Overloads
{
    using System.Collections.Generic;

    public class Order
    {
        private readonly List<Position> positions = new List<Position>();

        public List<Position> Positions
        {
            get { return this.positions; }
        }

        public void AddPosition(string articleNumber, int amount)
        {
            this.AddPosition(articleNumber, amount, string.Empty);
        }

        public void AddPosition(string articleNumber)
        {
            this.AddPosition(articleNumber, 1);
        }

        public void AddPosition(string articleNumber, int amount, string size)
        {
            this.AddPosition(articleNumber, amount, size, "black");
        }

        public void AddPosition(string articleNumber, int amount, string size, string color)
        {
            this.Positions.Add(new Position(articleNumber, amount, size, color));
        }
    }

    public class Position
    {
        public Position(string articleNumber, int amount, string size, string color)
        {
            this.ArticleNumber = articleNumber;
            this.Amount = amount;
            this.Size = size;
            this.Color = color;
        }

        public string ArticleNumber { get; private set; }
        public int Amount { get; private set; }
        public string Size { get; private set; }
        public string Color { get; private set; }
    }
}