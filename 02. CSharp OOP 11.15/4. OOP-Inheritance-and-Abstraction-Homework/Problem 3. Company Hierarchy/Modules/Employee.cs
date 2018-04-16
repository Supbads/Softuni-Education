using System;
using Problem_3.Company_Hierarchy.Interfaces;
using Problem_3.Company_Hierarchy.Modules;

namespace Problem_3.Company_Hierarchy
{
    class Employee : Person, IEmployee
    {
        private decimal salary;
        private string department;

        public Employee(string firstName, string lastname,int id, decimal salary, string department) : base(firstName,lastname,id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("Employee salary cannot be null");
                }
                if (value < 0m)
                {
                    throw new ArgumentException("Employee salary cannot be negative");
                }
                salary = value;
            }
        }

        public string Department
        {
            get { return department; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Employee department cannot be null");
                }
                if ((value != "Production") && (value != "Accounting") && (value != "Sales") && (value != "Marketing") )
                {
                    throw new ArgumentException("Employee department cannot be something other than: Production/Accounting/Sales/Marketing department");
                }
                department = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Department: {1} Salary: {2}{0}",Environment.NewLine, this.Department, this.Salary);
        }
    }
}
