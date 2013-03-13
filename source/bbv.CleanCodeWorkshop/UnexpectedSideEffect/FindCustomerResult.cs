// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindCustomerResult.cs" company="bbv Software Services AG">
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
    using System;

    public class FindCustomerResult
    {
        private readonly Customer customer;

        private FindCustomerResult(Customer customer)
        {
            this.customer = customer;
        }

        public Customer Customer
        {
            get
            {
                if (!this.Found)
                {
                    throw new InvalidOperationException("Customer was not found");
                }

                return this.customer;
            }
        }

        public bool Found
        {
            get { return this.customer != null; }
        }

        public static FindCustomerResult CreateNotFound()
        {
            return new FindCustomerResult(null);
        }

        public static FindCustomerResult CreateFound(Customer customer)
        {
            return new FindCustomerResult(customer);
        }


    }
}