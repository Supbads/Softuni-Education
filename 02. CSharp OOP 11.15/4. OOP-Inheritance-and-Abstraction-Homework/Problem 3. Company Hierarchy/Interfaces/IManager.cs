using System.Collections.Generic;

namespace Problem_3.Company_Hierarchy.Interfaces
{
    interface IManager
    {
        ISet<Employee> Employees { get; set; }
        void AddEmployees(ISet<Employee> employees);
    }
}
