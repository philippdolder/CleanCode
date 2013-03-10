namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    // This implementation is a dummy implementation to simplify the logic to find the correct customer object
    public class DummyCustomerFinder : ICustomerFinder
    {
        private readonly IMailDispatcher mailDispatcher;

        public DummyCustomerFinder(IMailDispatcher mailDispatcher)
        {
            this.mailDispatcher = mailDispatcher;
        }

        public ICustomer Find(string customerName)
        {
            if (customerName == "bbv")
            {
                return new LargeAccountCustomer(this.mailDispatcher);
            }

            if (customerName == "bbv ICT")
            {
                return new NewCustomer(this.mailDispatcher);
            }

            // TODO: return a null implementation instead of a null reference!
            return null;
        }
    }
}