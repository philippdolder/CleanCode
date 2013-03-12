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
            order.Positions.Add(new Position { Item = "Windows 8", Amount = 2 });
            order.Address += "; Switzerland";
            Parcel parcel = this.boxingService.Box(order);

            this.mailService.Deliver(order.Address, parcel);
        } 
    }
}