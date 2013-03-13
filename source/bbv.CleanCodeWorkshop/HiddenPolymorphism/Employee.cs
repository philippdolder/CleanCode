// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarriorBuilder.cs" company="bbv Software Services AG">
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

            throw new InvalidOperationException("EmployeType: `" + this.type + "` is not supported!");
        }
    }
}