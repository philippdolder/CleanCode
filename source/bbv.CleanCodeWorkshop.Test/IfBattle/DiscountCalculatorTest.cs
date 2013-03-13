namespace Bbv.CleanCodeWorkshop.IfBattle
{
    using FluentAssertions;
    using NUnit.Framework;

    // TODO: Refactor the DiscountCalculator in a way that it allows adding more rules and then fix the failing test at the end!
    // Important: Make sure you do small steps. Don't let all your tests fail, use parallel implementation etc.
    [TestFixture]
    public class DiscountCalculatorTest
    {
        private DiscountCalculator testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new DiscountCalculator();
        }

        [Test]
        public void HasNoDiscount_WhenNewCustomer()
        {
            var order = new Order(new Customer(), 50);
            
            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(0);
        }

        [Test]
        public void Has5PercentDiscount_WhenCustomerIsGoodCustomer()
        {
            var customer = new Customer { NumberOfOrders = 10 };
            var order = new Order(customer, 0);
            
            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(5);
        }

        [Test]
        public void GoodCustomerHas2PercentExtraDiscount_WhenOrderIsWorth100OrMore()
        {
            var customer = new Customer { NumberOfOrders = 10 };
            var order = new Order(customer, 100);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(7);
        }

        [Test]
        public void NewCustomerHas1PercentDiscount_WhenOrderIsWorth200OrMore()
        {
            var customer = new Customer();
            var order = new Order(customer, 200);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(1);
        }

        [Test]
        public void NewCustomerPays2PercentExtra_WhenOrderIsWorthLessThan30()
        {
            var customer = new Customer();
            var order = new Order(customer, 29);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(-2);
        }

        [Test]
        public void LargeAccountCustomerHas6PercentDiscount_WhenOrderIsLessThan200()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 199);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(6);
        }

        [Test]
        public void LargeAccountCustomerHas8PercentDiscount_WhenOrderIsWorth200OrMore()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 200);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(8);
        }

        // TODO: Refactor before you make that test work!
        [Test]
        public void LargeAccountCustomerAlwaysGetsTheBestDiscount()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 150);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(7);
        }
    }
}