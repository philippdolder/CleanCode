// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscountCalculator.cs" company="bbv Software Services AG">
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