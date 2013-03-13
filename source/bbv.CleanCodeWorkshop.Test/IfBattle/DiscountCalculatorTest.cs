namespace Bbv.CleanCodeWorkshop.IfBattle
{
    using System;
    using System.Collections.Generic;
    using FakeItEasy;
    using FluentAssertions;
    using NUnit.Framework;

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