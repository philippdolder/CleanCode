namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    using FakeItEasy;
    using NUnit.Framework;

    [TestFixture]
    public class NewsletterIntegrationTest
    {
        private IMailDispatcher mailDispatcher;
        private NewsletterService testee;

        [SetUp]
        public void SetUp()
        {
            this.mailDispatcher = A.Fake<IMailDispatcher>();

            this.testee = new NewsletterService(new DummyCustomerFinder(this.mailDispatcher));
        }

        [Test]
        public void SendsNewsletterToKnownCustomers()
        {
            const string Bbv = "bbv";
            const string BbvIct = "bbv ICT";
            const string UnknownCustomer = "not a customer";

            var customers = new[] { Bbv, BbvIct, UnknownCustomer };
            this.testee.SendNewsToCustomers(customers);

            A.CallTo(() => this.mailDispatcher.Send("As a large account customer you receive 5% back when you have a monthly volume of more than 1000$ in April 2013."))
                .MustHaveHappened(Repeated.Exactly.Once);

            A.CallTo(() => this.mailDispatcher.Send("As a new customer you have 10% on your next order over 100$"))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}