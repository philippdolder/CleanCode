// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceParser.cs" company="bbv Software Services AG">
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
    using System.Xml.Linq;

    public class InvoiceParser
    {
         public bool TryParse(XDocument invoiceDescription, out Invoice invoice)
         {
             XElement invoiceElement = invoiceDescription.Element("Invoice");
             XElement customerElement = invoiceElement.Element("Customer");
             XElement amountElement = invoiceElement.Element("Amount");

             if (!IsInvoiceValid(customerElement, amountElement))
             {
                 invoice = null;
                 return false;
             }

             invoice = new Invoice(customerElement.Value, Convert.ToInt32(amountElement.Value));
             return true;
         }

        private bool IsInvoiceValid(XElement customerElement, XElement amountElement)
        {
            int amount;
            return customerElement != null
                && !string.IsNullOrEmpty(customerElement.Value)
                && amountElement != null
                && int.TryParse(amountElement.Value, out amount);
        }
    }
}