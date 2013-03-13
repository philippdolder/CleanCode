// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscountCalculatorTest.cs" company="bbv Software Services AG">
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
    using FakeItEasy;
    using FluentAssertions;
    using NUnit.Framework;

    // Important: Make sure you do small steps. Don't let all your tests fail, use parallel implementation etc.
    [TestFixture]
    public class DiscountCalculatorTest
    {
        private DiscountCalculator testee;
        private List<IDiscountStrategy> strategies;

        [SetUp]
        public void SetUp()
        {
            this.strategies = new List<IDiscountStrategy>();

            this.testee = new DiscountCalculator(this.strategies);
        }

        [Test]
        public void ReturnsTheBestDiscount()
        {
            const int BadDiscount = 3;
            const int GoodDiscount = 5;

            var order = new Order(new Customer(), 0);

            var badDiscountStrategy = CreateDiscountStrategyThatQualifies(order, BadDiscount);
            var goodDiscountStrategy = CreateDiscountStrategyThatQualifies(order, GoodDiscount);
            this.strategies.Add(badDiscountStrategy);
            this.strategies.Add(goodDiscountStrategy);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(GoodDiscount);
        }

        [Test]
        public void IgnoresDiscountThatDoesNotQualify()
        {
            const int Discount = 5;

            var order = new Order(new Customer(), 0);

            var discountStrategy = CreateDiscountStrategyThatQualifies(order, Discount);
            var ignoredDiscountStrategy = CreateDiscountStrategyThatDoesNotQualify(order);
            this.strategies.Add(discountStrategy);
            this.strategies.Add(ignoredDiscountStrategy);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(Discount);
        }

        private static IDiscountStrategy CreateDiscountStrategyThatQualifies(Order order, int discount)
        {
            var discountStrategy = A.Fake<IDiscountStrategy>();
            A.CallTo(() => discountStrategy.QualifiesForDiscount(order.Customer)).Returns(true);
            A.CallTo(() => discountStrategy.CalculateDiscount(order)).Returns(discount);

            return discountStrategy;
        }

        private static IDiscountStrategy CreateDiscountStrategyThatDoesNotQualify(Order order)
        {
            var discountStrategy = A.Fake<IDiscountStrategy>();
            A.CallTo(() => discountStrategy.QualifiesForDiscount(order.Customer)).Returns(false);
            A.CallTo(() => discountStrategy.CalculateDiscount(A<Order>._)).Throws(new InvalidOperationException("Does not qualify for discount"));

            return discountStrategy;
        }
    }
}