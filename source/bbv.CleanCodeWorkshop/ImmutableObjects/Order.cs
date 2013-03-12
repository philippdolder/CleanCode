namespace Bbv.CleanCodeWorkshop.ImmutableObjects
{
    using System.Collections.Generic;

    public class Order
    {
        public Order(string address, IEnumerable<Position> positions)
        {
            this.Address = address;
            this.Positions = positions;
        }

        public string Address { get; private set; }

        public IEnumerable<Position> Positions { get; private set; }
    }
}