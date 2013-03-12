namespace Bbv.CleanCodeWorkshop.OutParameters
{
    using System;
    using System.Xml.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class InvoiceParserTest
    {
        private InvoiceParser testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new InvoiceParser();
        }

        [Test]
        public void ParsesInvoice()
        {
            const string Customer = "bbv Software Services AG";
            const int Amount = 1200;

            InvoiceParseResult result = this.testee.TryParse(CreateInvoice(Customer, Amount));

            result.Invoice.ShouldHave().AllProperties().EqualTo(new Invoice(Customer, Amount));
        }

        [Test]
        public void ReturnsTrue_WhenInvoiceCanBeParsed()
        {
            const string Customer = "bbv Software Services AG";
            const int Amount = 1200;

            InvoiceParseResult result = this.testee.TryParse(CreateInvoice(Customer, Amount));

            result.Parsed.Should().BeTrue();
        }

        [TestCase("", "100")]
        [TestCase("bbv", "")]
        public void ReturnsFalse_WhenInvoiceCannotBeParsed(string customer, string amount)
        {
            InvoiceParseResult result = this.testee.TryParse(CreateInvoice(customer, amount));

            result.Parsed.Should().BeFalse();
        }

        private static XDocument CreateInvoice(string customer, string amount)
        {
            var invoice = new XDocument();
            var root = new XElement("Invoice");
            invoice.Add(root);

            root.Add(new XElement("Customer", customer));
            root.Add(new XElement("Amount", amount));

            return invoice;
        }

        private static XDocument CreateInvoice(string customer, int amount)
        {
            return CreateInvoice(customer, Convert.ToString(amount));
        }
    }
}