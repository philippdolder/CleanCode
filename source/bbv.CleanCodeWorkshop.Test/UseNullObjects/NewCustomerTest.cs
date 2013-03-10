namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    using FakeItEasy;
    using NUnit.Framework;

    [TestFixture]
    public class NewCustomerTest
    {
        private IMailDispatcher dispatcher;
        private NewCustomer testee;

        [SetUp]
        public void SetUp()
        {
            this.dispatcher = A.Fake<IMailDispatcher>();

            this.testee = new NewCustomer(this.dispatcher);
        }

        [Test]
        public void SendsNewsletter()
        {
            this.testee.SendNewsletter();

            A.CallTo(() => this.dispatcher.Send("As a new customer you have 10% on your next order over 100$"))
                .MustHaveHappened();
        }
    }
}