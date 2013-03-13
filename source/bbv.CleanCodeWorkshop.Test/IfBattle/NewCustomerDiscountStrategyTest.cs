namespace Bbv.CleanCodeWorkshop.IfBattle
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class NewCustomerDiscountStrategyTest
    {
        private NewCustomerDiscountStrategy testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new NewCustomerDiscountStrategy();
        }

        [Test]
        public void EveryoneQualifiesForDiscount()
        {
            bool qualifies = this.testee.QualifiesForDiscount(new Customer { NumberOfOrders = 0 });

            qualifies.Should().BeTrue();
        }

        [Test]
        public void DiscountIs1Percent_WhenOrderIs200OrMore()
        {
            var customer = new Customer { NumberOfOrders = 0 };
            var order = new Order(customer, 200);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(1);
        }

        [Test]
        public void RetailSurchargeIs2Percent_WhenOrderIsWorthLessThan30()
        {
            var customer = new Customer { NumberOfOrders = 0 };
            var order = new Order(customer, 29);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(-2);
        }

        [TestCase(30)]
        [TestCase(31)]
        [TestCase(199)]
        public void NoDiscount_WhenOrderIs30OrMoreAndLessThan200(int orderValue)
        {
            var customer = new Customer { NumberOfOrders = 0 };
            var order = new Order(customer, orderValue);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(0);
        }
    }
}