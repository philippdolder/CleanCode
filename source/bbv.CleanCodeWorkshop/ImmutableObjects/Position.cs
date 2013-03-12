namespace Bbv.CleanCodeWorkshop.ImmutableObjects
{
    public class Position
    {
        public Position(string item, int amount)
        {
            this.Item = item;
            this.Amount = amount;
        }

        public string Item { get; private set; }

        public int Amount { get; private set; }
    }
}