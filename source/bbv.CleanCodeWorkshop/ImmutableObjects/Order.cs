namespace Bbv.CleanCodeWorkshop.ImmutableObjects
{
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            this.Positions = new List<Position>();
        }

        public string Address { get; set; }

        public IList<Position> Positions { get; private set; }
    }
}