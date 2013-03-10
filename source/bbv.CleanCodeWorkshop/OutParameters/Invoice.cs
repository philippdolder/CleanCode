namespace Bbv.CleanCodeWorkshop.OutParameters
{
    public class Invoice
    {
        public Invoice(string customer, int amount)
        {
            this.Customer = customer;
            this.Amount = amount;
        }

        public string Customer { get; private set; }
        public int Amount { get; private set; }
    }
}