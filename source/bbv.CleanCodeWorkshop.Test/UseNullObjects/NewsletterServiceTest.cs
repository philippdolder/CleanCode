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

namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    using System;
    using FakeItEasy;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class NewsletterServiceTest
    {
        private NewsletterService testee;
        private ICustomerFinder customerFinder;

        [SetUp]
        public void SetUp()
        {
            this.customerFinder = A.Fake<ICustomerFinder>();

            this.testee = new NewsletterService(this.customerFinder);
        }

        [Test]
        public void SendsNewsletterToSpecifiedCustomers()
        {
            const string Bbv = "bbv Software Services";
            const string BbvIct = "bbv ICT";

            var bbv = A.Fake<ICustomer>();
            var bbvIct = A.Fake<ICustomer>();
            A.CallTo(() => this.customerFinder.Find(Bbv)).Returns(bbv);
            A.CallTo(() => this.customerFinder.Find(BbvIct)).Returns(bbvIct);

            var customers = new[] { Bbv, BbvIct };
            this.testee.SendNewsToCustomers(customers);

            A.CallTo(() => bbv.SendNewsletter()).MustHaveHappened();
            A.CallTo(() => bbvIct.SendNewsletter()).MustHaveHappened();
        }

        [Test]
        public void SkipsUnknownCustomers()
        {
            const string UnknownCustomer = "unknown customer";

            ICustomer unknownCustomer = null;
            A.CallTo(() => this.customerFinder.Find(UnknownCustomer)).Returns(unknownCustomer);

            Action act = () => this.testee.SendNewsToCustomers(new[] { UnknownCustomer });

            act.ShouldNotThrow();
        }
    }
}