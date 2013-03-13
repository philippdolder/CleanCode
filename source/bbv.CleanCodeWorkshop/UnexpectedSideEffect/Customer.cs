namespace Bbv.CleanCodeWorkshop.UnexpectedSideEffect
{
    public class Customer
    {
        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}