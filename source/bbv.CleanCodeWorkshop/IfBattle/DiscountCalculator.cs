namespace Bbv.CleanCodeWorkshop.IfBattle
{
    using System;
    using System.Collections.Generic;

    public class DiscountCalculator
    {
        private readonly IEnumerable<IDiscountStrategy> discountStrategies;

        public DiscountCalculator(IEnumerable<IDiscountStrategy> discountStrategies)
        {
            this.discountStrategies = discountStrategies;
        }

        public int CalculateDiscount(Order order)
        {
            int maxDiscount = int.MinValue;

            foreach (var discountStrategy in this.discountStrategies)
            {
                bool qualifies = discountStrategy.QualifiesForDiscount(order.Customer);

                if (qualifies)
                {
                    int discount = discountStrategy.CalculateDiscount(order);
                    maxDiscount = Math.Max(maxDiscount, discount);
                }
            }

            return maxDiscount;
        }
    }
}