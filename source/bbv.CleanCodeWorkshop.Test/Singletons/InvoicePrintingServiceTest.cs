namespace Bbv.CleanCodeWorkshop.Singletons
{
    using System;
    using FakeItEasy;
    using NUnit.Framework;

    [TestFixture]
    public class InvoicePrintingServiceTest
    {
        private InvoicePrintingService testee;
        private IPrinter printer;

        [SetUp]
        public void SetUp()
        {
            this.printer = A.Fake<IPrinter>();
            this.testee = new InvoicePrintingService(this.printer);
        }

        [Test]
        public void PrintsInvoice()
        {
            var invoice = new Invoice(new DateTime(2013, 2, 27));

            this.testee.PrintInvoice(invoice);

            A.CallTo(() => this.printer.Print(invoice)).MustHaveHappened();
        }
    }
}