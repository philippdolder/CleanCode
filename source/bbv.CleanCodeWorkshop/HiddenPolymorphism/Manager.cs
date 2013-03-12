namespace Bbv.CleanCodeWorkshop.HiddenPolymorphism
{
    public class Manager : IEmployee
    {
        private readonly int monthlySalary;
        private readonly int bonus;

        public Manager(int monthlySalary, int bonus)
        {
            this.monthlySalary = monthlySalary;
            this.bonus = bonus;
        }

        public int CalculateSalary()
        {
            return this.monthlySalary + this.bonus;
        }
    }
}