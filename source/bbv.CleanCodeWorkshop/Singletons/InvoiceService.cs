namespace Bbv.CleanCodeWorkshop.Singletons
{
    using System;

    public class InvoiceService
    {
        public Invoice CreateInvoice()
        {
            return new Invoice(DateTime.Today);
        }
    }
}