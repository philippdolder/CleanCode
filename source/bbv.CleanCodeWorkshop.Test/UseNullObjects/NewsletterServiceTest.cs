namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    using System;
    using FakeItEasy;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class NewsletterServiceTest
    {
        private NewsletterService testee;
        private ICustomerFinder customerFinder;

        [SetUp]
        public void SetUp()
        {
            this.customerFinder = A.Fake<ICustomerFinder>();

            this.testee = new NewsletterService(this.customerFinder);
        }

        [Test]
        public void SendsNewsletterToSpecifiedCustomers()
        {
            const string Bbv = "bbv Software Services";
            const string BbvIct = "bbv ICT";

            var bbv = A.Fake<ICustomer>();
            var bbvIct = A.Fake<ICustomer>();
            A.CallTo(() => this.customerFinder.Find(Bbv)).Returns(bbv);
            A.CallTo(() => this.customerFinder.Find(BbvIct)).Returns(bbvIct);

            var customers = new[] { Bbv, BbvIct };
            this.testee.SendNewsToCustomers(customers);

            A.CallTo(() => bbv.SendNewsletter()).MustHaveHappened();
            A.CallTo(() => bbvIct.SendNewsletter()).MustHaveHappened();
        }

        [Test]
        public void SkipsUnknownCustomers()
        {
            const string UnknownCustomer = "unknown customer";

            ICustomer unknownCustomer = null;
            A.CallTo(() => this.customerFinder.Find(UnknownCustomer)).Returns(unknownCustomer);

            Action act = () => this.testee.SendNewsToCustomers(new[] { UnknownCustomer });

            act.ShouldNotThrow();
        }
    }
}