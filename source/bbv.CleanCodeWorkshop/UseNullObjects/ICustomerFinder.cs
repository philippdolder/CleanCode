namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    public interface ICustomerFinder
    {
        ICustomer Find(string customerName);
    }
}