namespace Bbv.CleanCodeWorkshop.ImmutableObjects
{
    public interface IMailService
    {
        void Deliver(string address, Parcel parcel); 
    }
}