// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LargeAccountCustomerDiscountStrategyTest.cs" company="bbv Software Services AG">
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
    public class LargeAccountCustomerDiscountStrategyTest
    {
        private LargeAccountCustomerDiscountStrategy testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new LargeAccountCustomerDiscountStrategy();
        }

        [Test]
        public void QualifiesForDiscount_WhenNumberOfOrdersIsGreaterOrEqualThan1000()
        {
            var customer = new Customer { NumberOfOrders = 1000 };

            bool qualifies = this.testee.QualifiesForDiscount(customer);

            qualifies.Should().BeTrue();
        }

        [Test]
        public void DoesNotQualifyForDiscount_WhenNumberOfOrdersIsLessThan1000()
        {
            var customer = new Customer { NumberOfOrders = 999 };

            bool qualifies = this.testee.QualifiesForDiscount(customer);

            qualifies.Should().BeFalse();
        }

        [Test]
        public void DiscountIs8Percent_WhenOrderIs200OrMore()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 200);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(8);
        }

        [Test]
        public void DiscountIs6Percent_WhenOrderIsLessThan200()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 199);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(6);
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