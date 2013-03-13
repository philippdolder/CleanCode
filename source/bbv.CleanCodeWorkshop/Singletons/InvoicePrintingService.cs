namespace Bbv.CleanCodeWorkshop.Singletons
{
    public class InvoicePrintingService
    {
        private readonly IPrinter printer;

        public InvoicePrintingService(IPrinter printer)
        {
            this.printer = printer;
        }

        public void PrintInvoice(Invoice invoice)
        {
            this.printer.Print(invoice);
        }
    }
}