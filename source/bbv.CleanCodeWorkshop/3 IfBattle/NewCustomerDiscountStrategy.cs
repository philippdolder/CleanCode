// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCustomerDiscountStrategy.cs" company="bbv Software Services AG">
//   Copyright (c) 2013
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//   http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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