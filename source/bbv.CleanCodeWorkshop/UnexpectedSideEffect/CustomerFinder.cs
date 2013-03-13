namespace Bbv.CleanCodeWorkshop.UnexpectedSideEffect
{
    using System.Collections.Generic;

    public class CustomerFinder
    {
        private readonly Dictionary<int, Customer> customers;

        public CustomerFinder()
        {
            this.customers = new Dictionary<int, Customer>();

            // The initialization is just to keep the example simple!
            this.customers.Add(1, new Customer("bbv"));
            this.customers.Add(2, new Customer("bbv ICT"));
        }

        public FindCustomerResult Find(int customerId)
        {
            if (!this.customers.ContainsKey(customerId))
            {
                return FindCustomerResult.CreateNotFound();
            }

            return FindCustomerResult.CreateFound(this.customers[customerId]);
        }
    }
}