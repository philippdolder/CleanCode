namespace Bbv.CleanCodeWorkshop.UseNullObjects
{
    public class LargeAccountCustomer : ICustomer
    {
        private readonly IMailDispatcher dispatcher;

        public LargeAccountCustomer(IMailDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public void SendNewsletter()
        {
            this.dispatcher.Send("As a large account customer you receive 5% back when you have a monthly volume of more than 1000$ in April 2013.");
        }
    }
}