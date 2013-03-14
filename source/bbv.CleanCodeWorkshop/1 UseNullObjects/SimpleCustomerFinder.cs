// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleCustomerFinder.cs" company="bbv Software Services AG">
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
    // This implementation is a simple implementation to simplify the logic to find the correct customer object
    public class SimpleCustomerFinder : ICustomerFinder
    {
        private readonly IMailDispatcher mailDispatcher;

        public SimpleCustomerFinder(IMailDispatcher mailDispatcher)
        {
            this.mailDispatcher = mailDispatcher;
        }

        public ICustomer Find(string customerName)
        {
            if (customerName == "bbv")
            {
                return new LargeAccountCustomer(this.mailDispatcher);
            }

            if (customerName == "bbv ICT")
            {
                return new NewCustomer(this.mailDispatcher);
            }

            // TODO: return a null implementation instead of a null reference!
            return null;
        }
    }
}