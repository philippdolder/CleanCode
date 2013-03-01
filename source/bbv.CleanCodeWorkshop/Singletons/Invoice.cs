namespace Bbv.CleanCodeWorkshop.Singletons
{
    using System;

    public class Invoice
    {
        public Invoice(DateTime date)
        {
            this.Date = date;
        }

        public DateTime Date { get; private set; }
    }
}