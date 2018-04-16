using System.Collections.Generic;

namespace Employees.Services.Contracts
{
    using Employees.DataModels;
    using System;

    public interface IEmployeeService
    {
        EmployeeDto ById(int id);

        void AddEmployee(EmployeeDto employeeDto);

        EmployeeDto SetBirthDay(int id, DateTime birthDay);

        EmployeeDto SetAddress(int id, string address);

        EmployeePersonalDto EmployeePersonalInfo(int id);

        EmployeeDto EmployeeInfo(int id);

        string SetManager(int employeeId, int managerId);

        ManagerDto ManagerInfo(int id);

        ICollection<EmployeeWorkDto> EmployeesOlderThan(int age);
    }
}