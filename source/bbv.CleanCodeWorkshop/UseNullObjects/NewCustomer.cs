namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    public class NewCustomer : ICustomer
    {
        private readonly IMailDispatcher dispatcher;

        public NewCustomer(IMailDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public void SendNewsletter()
        {
            this.dispatcher.Send("As a new customer you have 10% on your next order over 100$");
        }
    }
}