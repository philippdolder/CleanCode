// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarriorBuilder.cs" company="bbv Software Services AG">
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