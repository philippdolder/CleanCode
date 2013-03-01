namespace Bbv.CleanCodeWorkshop.IfBattle
{
    public class Order
    {
        public Order(Customer customer, int orderValue)
        {
            this.Customer = customer;
            this.Value = orderValue;
        }

        public Customer Customer { get; private set; }

        public int Value { get; private set; }
    }
}