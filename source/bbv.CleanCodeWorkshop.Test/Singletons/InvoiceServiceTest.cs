namespace Bbv.CleanCodeWorkshop.Singletons
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    // TODO: Refactor the code in a way that you can implement the failing test properly (today has to remain 2013-02-27!!)
    [TestFixture]
    public class InvoiceServiceTest
    {
        private InvoiceService testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new InvoiceService();
        }

        [Test]
        public void SetsTheCurrentDate()
        {
            var today = new DateTime(2013, 2, 27);

            var invoice = this.testee.CreateInvoice();

            invoice.Date.Should().Be(today);
        }
    }
}