namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    public class Invoice
    {
        public Invoice(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; private set; }
    }
}