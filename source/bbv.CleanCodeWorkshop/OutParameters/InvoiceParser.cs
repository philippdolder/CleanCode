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