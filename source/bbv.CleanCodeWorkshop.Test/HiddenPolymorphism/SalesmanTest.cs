namespace Bbv.CleanCodeWorkshop.HiddenPolymorphism
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class SalesmanTest
    {
        [Test]
        public void HasCommission()
        {
            const int MonthlySalary = 6000;
            const int Commission = 500;

            var salesman = new Salesman(MonthlySalary, Commission);
            int salaryToPay = salesman.CalculateSalary();

            salaryToPay.Should().Be(MonthlySalary + Commission);
        }
    }
}