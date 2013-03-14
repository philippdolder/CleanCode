// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerFinder.cs" company="bbv Software Services AG">
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
    using System.Collections.Generic;

    public class CustomerFinder
    {
        private readonly Dictionary<int, Customer> customers;

        public CustomerFinder()
        {
            this.customers = new Dictionary<int, Customer>();

            // The initialization is just to keep the example simple!
            this.customers.Add(1, new Customer("bbv"));
            this.customers.Add(2, new Customer("bbv ICT"));
        }

        public Customer Find(int customerId)
        {
            if (!this.customers.ContainsKey(customerId))
            {
                this.customers.Add(customerId, new Customer(string.Empty));
            }

            return this.customers[customerId];
        }
    }
}