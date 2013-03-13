namespace Bbv.CleanCodeWorkshop.UnexpectedSideEffect
{
    using FluentAssertions;
    using NUnit.Framework;

    // TODO: Change the SimpleCustomerFinder implementation so that the 'Find' method has no side effects.
    // e.g. add a query method to check for a customer to exist! or return a FindResult
    // The finder should never create a customer. Creation of customers should be handled by another class (Single Responsibility Principle)
    [TestFixture]
    public class CustomerFinderTest
    {
        private CustomerFinder testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new CustomerFinder();
        }

        [Test]
        public void GetsTheCustomer()
        {
            const int Id = 1;

            Customer customer = this.testee.Find(Id);

            customer.Name.Should().Be("bbv");
        }

        [Test]
        public void CreatesANewCustomer_WhenItDoesNotExist()
        {
            const int NotExistingId = 3;

            Customer customer = this.testee.Find(NotExistingId);

            customer.Should().NotBeNull();
        }
    }
}