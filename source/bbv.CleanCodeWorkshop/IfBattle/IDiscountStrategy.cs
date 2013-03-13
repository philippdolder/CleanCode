namespace Bbv.CleanCodeWorkshop.IfBattle
{
    public interface IDiscountStrategy
    {
        bool QualifiesForDiscount(Customer customer);

        int CalculateDiscount(Order order);
    }
}