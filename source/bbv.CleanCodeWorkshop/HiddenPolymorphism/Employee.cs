namespace Bbv.CleanCodeWorkshop.HiddenPolymorphism
{
    using System;

    public class Employee
    {
        private readonly EmployeeType type;
        private readonly int monthlySalary;
        private readonly int bonus;
        private readonly int commission;

        public Employee(EmployeeType type, int monthlySalary, int bonus, int commission)
        {
            this.type = type;
            this.monthlySalary = monthlySalary;
            this.bonus = bonus;
            this.commission = commission;
        }

        public int CalculateSalary()
        {
            if (this.type == EmployeeType.Engineer)
            {
                return this.monthlySalary;
            }

            if (this.type == EmployeeType.Manager)
            {
                return this.monthlySalary + this.bonus;
            }

            if (this.type == EmployeeType.Salesman)
            {
                return this.monthlySalary + this.commission;
            }

            throw new Exception("EmployeType: `" + this.type + "` is not supported!");
        }
    }
}