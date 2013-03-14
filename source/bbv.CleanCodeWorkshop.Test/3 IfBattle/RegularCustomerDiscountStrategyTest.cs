// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegularCustomerDiscountStrategyTest.cs" company="bbv Software Services AG">
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
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class RegularCustomerDiscountStrategyTest
    {
        private RegularCustomerDiscountStrategy testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new RegularCustomerDiscountStrategy();
        }

        [Test]
        public void QualifiesForDiscount_WhenNumberOfOrdersIsGreaterOrEqualThan10()
        {
            var customer = new Customer { NumberOfOrders = 10 };

            bool qualifies = this.testee.QualifiesForDiscount(customer);

            qualifies.Should().BeTrue();
        }

        [Test]
        public void DoesNotQualifyForDiscount_WhenNumberOfOrdersIsLessThan10()
        {
            var customer = new Customer { NumberOfOrders = 9 };

            bool qualifies = this.testee.QualifiesForDiscount(customer);

            qualifies.Should().BeFalse();
        }

        [Test]
        public void DiscountIs7Percent_WhenOrderIs100OrMore()
        {
            var customer = new Customer { NumberOfOrders = 10 };
            var order = new Order(customer, 100);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(7);
        }

        [Test]
        public void DiscountIs5Percent_WhenOrderIsLessThan100()
        {
            var customer = new Customer { NumberOfOrders = 10 };
            var order = new Order(customer, 99);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(5);
        }

        [Test]
        public void CannotCalculateDiscount_WhenCustomerDoesNotQualify()
        {
            var newCustomer = new Customer { NumberOfOrders = 5 };
            var order = new Order(newCustomer, 199);

            Action act = () => this.testee.CalculateDiscount(order);

            act.ShouldThrow<InvalidOperationException>();
        }
    }
}