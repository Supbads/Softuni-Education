using System;
using System.Collections.Generic;
using System.Text;
using Employees.Services;
using Employees.Services.Contracts;
using Employees.Startup.Commands.Contracts;

namespace Employees.Startup.Commands
{
    class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public EmployeePersonalInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        
        public string Execute(params string[] parameters)
        {
            int employeeId = int.Parse(parameters[0]);

            var employee = employeeService.EmployeePersonalInfo(employeeId);

            var birthday = "[No Birthday]";

            if (employee.BirthDay.HasValue)
            {
                birthday = employee.BirthDay.Value.ToShortDateString();
            }

            var address = employee.Address ?? "[No Address]";

            return $"ID: {employeeId} - {employee.FirstName} {employee.LastName} - ${employee.Salary:F2}" + Environment.NewLine +
                   $"Birthday: {birthday}" + Environment.NewLine +
                   $"Address: {address}";
        }
    }
}