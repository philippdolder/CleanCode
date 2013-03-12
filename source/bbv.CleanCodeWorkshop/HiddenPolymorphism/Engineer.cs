namespace Bbv.CleanCodeWorkshop.HiddenPolymorphism
{
    public class Engineer : IEmployee
    {
        private readonly int monthlySalary;

        public Engineer(int monthlySalary)
        {
            this.monthlySalary = monthlySalary;
        }

        public int CalculateSalary()
        {
            return this.monthlySalary;
        }
    }
}