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

namespace Bbv.CleanCodeWorkshop.UnexpectedSideEffect
{
    using FluentAssertions;
    using NUnit.Framework;

    // TODO: Change the SimpleCustomerFinder implementation so that the 'Find' method has no side effects.
    // e.g. add a query method to check for a customer to exist! or return a FindResult
    // The finder should never create a customer. Creation of customers should be handled by another class (Single Responsibility Principle)
    [TestFixture]
    public class CustomerFinderTest
    {
        private CustomerFinder testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new CustomerFinder();
        }

        [Test]
        public void GetsTheCustomer()
        {
            const int Id = 1;

            Customer customer = this.testee.Find(Id);

            customer.Name.Should().Be("bbv");
        }

        [Test]
        public void CreatesANewCustomer_WhenItDoesNotExist()
        {
            const int NotExistingId = 3;

            Customer customer = this.testee.Find(NotExistingId);

            customer.Should().NotBeNull();
        }
    }
}