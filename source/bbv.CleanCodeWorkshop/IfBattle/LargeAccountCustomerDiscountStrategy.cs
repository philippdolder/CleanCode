namespace Bbv.CleanCodeWorkshop.IfBattle
{
    using System;

    public class LargeAccountCustomerDiscountStrategy : IDiscountStrategy
    {
        private const int DiscountForSmallOrders = 6;
        private const int DiscountForLargeOrders = 8;
        private const int MinimumValueOfLargeOrders = 200;
        private const int MinimumNumberOfOrdersToQualify = 1000;

        public bool QualifiesForDiscount(Customer customer)
        {
            return IsLargeAccountCustomer(customer);
        }

        public int CalculateDiscount(Order order)
        {
            this.EnsureQualifiesForDiscount(order.Customer);

            if (IsLargeOrder(order))
            {
                return DiscountForLargeOrders;
            }

            return DiscountForSmallOrders;
        }

        private static bool IsLargeOrder(Order order)
        {
            return order.Value >= MinimumValueOfLargeOrders;
        }

        private static bool IsLargeAccountCustomer(Customer customer)
        {
            return customer.NumberOfOrders >= MinimumNumberOfOrdersToQualify;
        }

        private void EnsureQualifiesForDiscount(Customer customer)
        {
            if (!this.QualifiesForDiscount(customer))
            {
                throw new InvalidOperationException("Customer does not qualify for large account discount");
            }
        }
    }
}