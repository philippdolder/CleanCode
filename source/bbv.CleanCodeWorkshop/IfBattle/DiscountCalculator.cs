namespace Bbv.CleanCodeWorkshop.IfBattle
{
    public class DiscountCalculator
    {
        public int CalculateDiscount(Order order)
        {
            if (order.Customer.NumberOfOrders >= 1000)
            {
                if (order.Value >= 200)
                {
                    return 8;
                }

                return 6;
            }

            if (order.Customer.NumberOfOrders >= 10)
            {
                int discount = 5;
                if (order.Value >= 100)
                {
                    discount += 2;
                }

                return discount;
            }

            if (order.Value >= 200)
            {
                return 1;
            }

            if (order.Value < 30)
            {
                return -2;
            }

            return 0;
        }
    }
}