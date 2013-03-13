// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerFinderTest.cs" company="bbv Software Services AG">
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

    // The finder should never create a customer. Creation of customers should be handled by another class (Single Responsibility Principle)
    // This is the minimal solution. You can also add a class that creates a customer and adds it to the list of customers
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
        public void FindsTheCustomer()
        {
            const int Id = 1;

            FindCustomerResult result = this.testee.Find(Id);

            result.Found.Should().BeTrue();
            result.Customer.Name.Should().Be("bbv");
        }

        [Test]
        public void ReturnsNotFound_WhenCustomerDoesNotExist()
        {
            const int NotExistingId = 3;

            FindCustomerResult result = this.testee.Find(NotExistingId);

            result.Found.Should().BeFalse();
        }
    }
}