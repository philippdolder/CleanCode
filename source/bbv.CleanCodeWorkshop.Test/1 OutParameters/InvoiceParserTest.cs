// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceParserTest.cs" company="bbv Software Services AG">
//   Copyright (c) 2013
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//   http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Bbv.CleanCodeWorkshop.OutParameters
{
    using System;
    using System.Xml.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    // TODO: Refactor the code so that you don't have an 'out' parameter anymore. But don't return 'null' when you cannot parse the invoice!
    // Hint: use a Result object
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

            Invoice invoice;
            this.testee.TryParse(CreateInvoice(Customer, Amount), out invoice);

            invoice.ShouldHave().AllProperties().EqualTo(new Invoice(Customer, Amount));
        }

        [Test]
        public void ReturnsTrue_WhenInvoiceCanBeParsed()
        {
            const string Customer = "bbv Software Services AG";
            const int Amount = 1200;

            Invoice invoice;
            bool result = this.testee.TryParse(CreateInvoice(Customer, Amount), out invoice);

            result.Should().BeTrue();
        }

        [TestCase("", "100")]
        [TestCase("bbv", "")]
        public void InvoiceIsNull_WhenInvoiceCannotBeParsed(string customer, string amount)
        {
            Invoice invoice;
            this.testee.TryParse(CreateInvoice(customer, amount), out invoice);

            invoice.Should().BeNull();
        }

        [TestCase("", "100")]
        [TestCase("bbv", "")]
        public void ReturnsFalse_WhenInvoiceCannotBeParsed(string customer, string amount)
        {
            Invoice invoice;
            bool result = this.testee.TryParse(CreateInvoice(customer, amount), out invoice);

            result.Should().BeFalse();
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