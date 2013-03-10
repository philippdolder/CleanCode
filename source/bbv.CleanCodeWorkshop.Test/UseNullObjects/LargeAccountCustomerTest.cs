namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    using FakeItEasy;
    using NUnit.Framework;

    [TestFixture]
    public class LargeAccountCustomerTest
    {
        private LargeAccountCustomer testee;
        private IMailDispatcher dispatcher;

        [SetUp]
        public void SetUp()
        {
            this.dispatcher = A.Fake<IMailDispatcher>();

            this.testee = new LargeAccountCustomer(this.dispatcher);
        }

        [Test]
        public void SendsNewsletter()
        {
            this.testee.SendNewsletter();

            A.CallTo(() => this.dispatcher.Send("As a large account customer you receive 5% back when you have a monthly volume of more than 1000$ in April 2013."))
                .MustHaveHappened();
        }
    }
}