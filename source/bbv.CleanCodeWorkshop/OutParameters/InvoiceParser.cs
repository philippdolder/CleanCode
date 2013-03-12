namespace Bbv.CleanCodeWorkshop.OutParameters
{
    using System;
    using System.Xml.Linq;

    public class InvoiceParser
    {
         public InvoiceParseResult TryParse(XDocument invoiceDescription)
         {
             XElement invoiceElement = invoiceDescription.Element("Invoice");
             XElement customerElement = invoiceElement.Element("Customer");
             XElement amountElement = invoiceElement.Element("Amount");

             if (!IsInvoiceValid(customerElement, amountElement))
             {
                 return InvoiceParseResult.CreateUnsuccessful();
             }

             var invoice = new Invoice(customerElement.Value, Convert.ToInt32(amountElement.Value));
             return InvoiceParseResult.CreateSuccessful(invoice);
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