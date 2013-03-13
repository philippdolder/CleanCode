// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegularCustomerDiscountStrategy.cs" company="bbv Software Services AG">
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