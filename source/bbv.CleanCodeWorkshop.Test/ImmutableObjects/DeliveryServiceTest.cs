namespace Bbv.CleanCodeWorkshop.ImmutableObjects
{
    using System.Collections.Generic;
    using FakeItEasy;
    using NUnit.Framework;

    [TestFixture]
    public class DeliveryServiceTest
    {
        private DeliveryService testee;
        private IMailService mailService;
        private IBoxingService boxingService;

        [SetUp]
        public void SetUp()
        {
            this.mailService = A.Fake<IMailService>();
            this.boxingService = A.Fake<IBoxingService>();

            this.testee = new DeliveryService(this.mailService, this.boxingService);
        }

        [Test]
        public void SendsTheBoxedOrderByMail()
        {
            const string Address = "bbv Software Serivces AG; Luzern";
            var positions = new List<Position>
                                {
                                    new Position("Visual Studio", 3), 
                                    new Position("ReSharper", 2)
                                };
            var order = new Order(Address, positions);

            var parcel = new Parcel();
            A.CallTo(() => this.boxingService.Box(positions)).Returns(parcel);

            this.testee.Deliver(order);

            A.CallTo(() => this.mailService.Deliver(Address, parcel)).MustHaveHappened();
        }
    }
}