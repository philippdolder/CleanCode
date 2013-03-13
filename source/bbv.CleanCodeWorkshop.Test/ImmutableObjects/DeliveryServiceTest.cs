// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryServiceTest.cs" company="bbv Software Services AG">
//   Copyright (c) 2013
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//   http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Bbv.CleanCodeWorkshop.ImmutableObjects
{
    using FakeItEasy;
    using NUnit.Framework;

    // What about the 'Windows 8' that are boxed? DeliveryService.cs:Line 16
    // What about the change of the delivery address before sending the package?
    // TODO: Refactor the Order and Position so that objects of these types are immutable (read-only).
    // TODO: Reduce the interface of IBoxingService.Box(Order) to a minimum
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
            var order = new Order { Address = "bbv Software Serivces AG; Luzern" };
            order.Positions.Add(new Position { Item = "Visual Studio", Amount = 3 });
            order.Positions.Add(new Position { Item = "ReSharper", Amount = 2 });

            var parcel = new Parcel();
            A.CallTo(() => this.boxingService.Box(order)).Returns(parcel);

            this.testee.Deliver(order);

            A.CallTo(() => this.mailService.Deliver(order.Address, parcel)).MustHaveHappened();
        }
    }
}