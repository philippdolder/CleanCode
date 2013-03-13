// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarriorBuilder.cs" company="bbv Software Services AG">
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