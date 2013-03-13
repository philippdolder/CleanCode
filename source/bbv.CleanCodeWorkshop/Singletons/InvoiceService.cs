namespace Bbv.CleanCodeWorkshop.Singletons
{
    public class InvoiceService
    {
        private readonly IDateProvider dateProvider;

        public InvoiceService(IDateProvider dateProvider)
        {
            this.dateProvider = dateProvider;
        }

        public Invoice CreateInvoice()
        {
            return new Invoice(this.dateProvider.Today);
        }
    }
}