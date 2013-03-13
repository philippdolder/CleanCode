namespace Bbv.CleanCodeWorkshop.Singletons
{
    using System;
    using FakeItEasy;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class InvoiceServiceTest
    {
        private InvoiceService testee;
        private IDateProvider dateProvider;

        [SetUp]
        public void SetUp()
        {
            this.dateProvider = A.Fake<IDateProvider>();
            this.testee = new InvoiceService(this.dateProvider);
        }

        [Test]
        public void SetsTheCurrentDate()
        {
            var today = new DateTime(2013, 2, 27);
            A.CallTo(() => this.dateProvider.Today).Returns(today);

            var invoice = this.testee.CreateInvoice();

            invoice.Date.Should().Be(today);
        }
    }
}