namespace Bbv.CleanCodeWorkshop.HiddenPolymorphism
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class EngineerTest
    {
        [Test]
        public void HasMonthlySalary()
        {
            const int MonthlySalary = 5000;

            var engineer = new Engineer(MonthlySalary);
            int salaryToPay = engineer.CalculateSalary();

            salaryToPay.Should().Be(MonthlySalary);
        }
    }
}