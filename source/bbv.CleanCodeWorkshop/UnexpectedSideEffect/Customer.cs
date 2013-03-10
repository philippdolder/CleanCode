namespace Bbv.CleanCodeWorkshop.UnexpectedSideEffect
{
    public class Customer
    {
        public Customer(string customerName)
        {
            this.CustomerName = customerName;
        }

        public string CustomerName { get; private set; }
    }
}