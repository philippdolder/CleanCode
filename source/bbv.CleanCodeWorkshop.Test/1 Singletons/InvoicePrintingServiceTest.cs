// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoicePrintingServiceTest.cs" company="bbv Software Services AG">
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