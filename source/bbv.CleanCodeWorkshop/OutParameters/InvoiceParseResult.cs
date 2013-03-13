// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceParseResult.cs" company="bbv Software Services AG">
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

    public class InvoiceParseResult
    {
        private readonly Invoice invoice;

        public static InvoiceParseResult CreateSuccessful(Invoice invoice)
        {
            return new InvoiceParseResult(true, invoice);
        }

        public static InvoiceParseResult CreateUnsuccessful()
        {
            return new InvoiceParseResult(false, null);
        }

        private InvoiceParseResult(bool parsed, Invoice invoice)
        {
            this.Parsed = parsed;
            this.invoice = invoice;
        }

        public bool Parsed { get; private set; }

        public Invoice Invoice
        {
            get
            {
                if (!this.Parsed)
                {
                    throw new InvalidOperationException("The Invoice is not available when it could not be parsed!");
                }

                return this.invoice;
            }
        }
    }
}