namespace Bbv.CleanCodeWorkshop.HiddenPolymorphism
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class ManagerTest
    {
        [Test]
        public void HasBonus()
        {
            const int MonthlySalary = 7000;
            const int Bonus = 1000;

            var manager = new Manager(MonthlySalary, Bonus);
            int salaryToPay = manager.CalculateSalary();

            salaryToPay.Should().Be(MonthlySalary + Bonus);
        }
    }
}