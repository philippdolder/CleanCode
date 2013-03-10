namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    using System.Collections.Generic;

    public class NewsletterService
    {
        private readonly ICustomerFinder customerFinder;

        public NewsletterService(ICustomerFinder customerFinder)
        {
            this.customerFinder = customerFinder;
        }

        public void SendNewsToCustomers(IEnumerable<string> customerNames)
        {
            foreach (string customerName in customerNames)
            {
                var customer = this.customerFinder.Find(customerName);

                if (customer != null)
                {
                    customer.SendNewsletter();
                }
            }
        }
    }
}