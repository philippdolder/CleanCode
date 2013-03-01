namespace Bbv.CleanCodeWorkshop.HiddenPolymorphism
{
    using FluentAssertions;
    using NUnit.Framework;

    // TODO: Refactor the code so that you can add an 'Administrative' employee without changing existing code!
    // HINT: get rid of the if statements and that ugly exception.
    [TestFixture]
    public class EmployeeTest
    {
        [Test]
        public void HasMonthlySalary_WhenEngineer()
        {
            const int MonthlySalary = 5000;
            
            var engineer = new Employee(EmployeeType.Engineer, MonthlySalary, 0, 0);
            int salaryToPay = engineer.CalculateSalary();

            salaryToPay.Should().Be(MonthlySalary);
        }

        [Test]
        public void HasBonus_WhenManager()
        {
            const int MonthlySalary = 7000;
            const int Bonus = 1000;
            
            var manager = new Employee(EmployeeType.Manager, MonthlySalary, Bonus, 0);
            int salaryToPay = manager.CalculateSalary();

            salaryToPay.Should().Be(MonthlySalary + Bonus);
        }

        [Test]
        public void HasCommission_WhenSalesman()
        {
            const int MonthlySalary = 6000;
            const int Commission = 500;

            var salesman = new Employee(EmployeeType.Salesman, MonthlySalary, 0, Commission);
            int salaryToPay = salesman.CalculateSalary();

            salaryToPay.Should().Be(MonthlySalary + Commission);
        }
    }
}