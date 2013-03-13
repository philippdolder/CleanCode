namespace Bbv.CleanCodeWorkshop.IfBattle
{
    public class NewCustomerDiscountStrategy : IDiscountStrategy
    {
        private const int MinimumValueOfLargeOrders = 200;
        private const int MinimumValueOfAverageOrders = 30;
        private const int LargeOrderDiscount = 1;
        private const int AverageOrderDiscount = 0;
        private const int SmallOrderSurcharge = -2;

        public bool QualifiesForDiscount(Customer customer)
        {
            return true;
        }

        public int CalculateDiscount(Order order)
        {
            if (IsLargeOrder(order))
            {
                return LargeOrderDiscount;
            }

            if (IsAverageOrder(order))
            {
                return AverageOrderDiscount;
            }

            return SmallOrderSurcharge;
        }

        private static bool IsAverageOrder(Order order)
        {
            return order.Value >= MinimumValueOfAverageOrders;
        }

        private static bool IsLargeOrder(Order order)
        {
            return order.Value >= MinimumValueOfLargeOrders;
        }
    }
}