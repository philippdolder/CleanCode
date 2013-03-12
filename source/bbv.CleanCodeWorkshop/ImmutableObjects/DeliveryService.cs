namespace Bbv.CleanCodeWorkshop.ImmutableObjects
{
    public class DeliveryService
    {
        private readonly IMailService mailService;
        private readonly IBoxingService boxingService;

        public DeliveryService(IMailService mailService, IBoxingService boxingService)
        {
            this.mailService = mailService;
            this.boxingService = boxingService;
        }

        public void Deliver(Order order)
        {
            Parcel parcel = this.boxingService.Box(order.Positions);

            this.mailService.Deliver(order.Address, parcel);
        } 
    }
}