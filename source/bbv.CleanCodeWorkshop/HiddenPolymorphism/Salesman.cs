namespace Bbv.CleanCodeWorkshop.HiddenPolymorphism
{
    public class Salesman : IEmployee
    {
        private readonly int monthlySalary;
        private readonly int commission;

        public Salesman(int monthlySalary, int commission)
        {
            this.monthlySalary = monthlySalary;
            this.commission = commission;
        }

        public int CalculateSalary()
        {
            return this.monthlySalary + this.commission;
        }
    }
}