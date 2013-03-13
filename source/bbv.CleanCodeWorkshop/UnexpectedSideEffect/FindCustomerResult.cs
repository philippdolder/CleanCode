namespace Bbv.CleanCodeWorkshop.UnexpectedSideEffect
{
    using System;

    public class FindCustomerResult
    {
        private readonly Customer customer;

        private FindCustomerResult(Customer customer)
        {
            this.customer = customer;
        }

        public Customer Customer
        {
            get
            {
                if (!this.Found)
                {
                    throw new InvalidOperationException("Customer was not found");
                }

                return this.customer;
            }
        }

        public bool Found
        {
            get { return this.customer != null; }
        }

        public static FindCustomerResult CreateNotFound()
        {
            return new FindCustomerResult(null);
        }

        public static FindCustomerResult CreateFound(Customer customer)
        {
            return new FindCustomerResult(customer);
        }


    }
}