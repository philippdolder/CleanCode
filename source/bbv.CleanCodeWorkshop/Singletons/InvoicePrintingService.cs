namespace Bbv.CleanCodeWorkshop.Singletons
{
    public class InvoicePrintingService
    {
        public void PrintInvoice(Invoice invoice)
        {
            Printer.Instance.Print(invoice);
        }
    }
}