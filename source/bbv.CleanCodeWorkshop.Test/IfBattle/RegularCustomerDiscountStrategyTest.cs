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