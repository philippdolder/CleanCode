namespace Bbv.CleanCodeWorkshop.Singletons
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class InvoicePrintingServiceTest
    {
        private InvoicePrintingService testee;

        // TODO: implement the Printer in a way that it can be asserted in the failing test. Replace the singleton with an Interface and an implementation
        [SetUp]
        public void SetUp()
        {
            this.testee = new InvoicePrintingService();
        }

        [Test]
        public void PrintsInvoice()
        {
            var invoice = new Invoice(new DateTime(2013, 2, 27));
            this.testee.PrintInvoice(invoice);

            // Cannot assert that the invoice was printed :-(
            true.Should().BeFalse();
        }
    }
}