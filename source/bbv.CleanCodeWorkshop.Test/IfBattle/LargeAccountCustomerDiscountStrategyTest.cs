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