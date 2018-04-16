using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem_3.Company_Hierarchy.Interfaces;

namespace Problem_3.Company_Hierarchy.Modules
{
    class Manager : Employee, IManager
    {
        private ISet<Employee> _employees;

        public Manager(string firstName, string lastname, int id, decimal salary, string department,ISet<Employee> employees = null) : base(firstName, lastname, id, salary, department)
        {
            this.Employees = employees ?? new HashSet<Employee>();
        }


        public ISet<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public void AddEmployees(ISet<Employee> employees)
        {
            if (employees == null)
            {
                throw new ArgumentNullException("Employees cannot be null");
            }
            _employees = employees;
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("Employees cannot be null");
            }
            if (_employees.Any(e => (e.FirstName == employee.FirstName)&&(e.LastName==employee.LastName)))
            {
                throw new ArgumentException("An employee with the same first name and last name already exists");
            }
            _employees.Add(employee);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Manager: ");
            sb.Append(base.ToString());
            sb.AppendLine("Has employees:");
            foreach (Employee employee in Employees)
            {
                sb.AppendFormat("{0} {1} Salary: {2} Department: {3}{4}", employee.FirstName, employee.LastName, employee.Salary, employee.Department, Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
