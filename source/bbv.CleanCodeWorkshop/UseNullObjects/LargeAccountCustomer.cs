// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LargeAccountCustomer.cs" company="bbv Software Services AG">
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
    public class LargeAccountCustomer : ICustomer
    {
        private readonly IMailDispatcher dispatcher;

        public LargeAccountCustomer(IMailDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public void SendNewsletter()
        {
            this.dispatcher.Send("As a large account customer you receive 5% back when you have a monthly volume of more than 1000$ in April 2013.");
        }
    }
}