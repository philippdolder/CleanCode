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