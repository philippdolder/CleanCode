namespace Bbv.CleanCodeWorkshop.IfBattle
{
    using System;

    public class RegularCustomerDiscountStrategy : IDiscountStrategy
    {
        private const int DiscountForSmallOrders = 5;
        private const int DiscountForLargeOrders = 7;
        private const int MinimumValueOfLargeOrders = 100;
        private const int MinimumNumberOfOrdersToQualify = 10;

        public bool QualifiesForDiscount(Customer customer)
        {
            return IsRegularCustomer(customer);
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

        private static bool IsRegularCustomer(Customer customer)
        {
            return customer.NumberOfOrders >= MinimumNumberOfOrdersToQualify;
        }

        private void EnsureQualifiesForDiscount(Customer customer)
        {
            if (!this.QualifiesForDiscount(customer))
            {
                throw new InvalidOperationException("Customer does not qualify for regular customer discount");
            }
        }
    }
}