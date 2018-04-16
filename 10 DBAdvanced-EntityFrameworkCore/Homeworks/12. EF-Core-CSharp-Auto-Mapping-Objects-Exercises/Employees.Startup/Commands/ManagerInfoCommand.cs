using System.Text;
using Employees.DataModels;

namespace Employees.Startup.Commands
{
    using Contracts;
    using Employees.Services.Contracts;

    public class ManagerInfoCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public ManagerInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] parameters)
        {
            var managerId = int.Parse(parameters[0]);

            var managerDto = employeeService.ManagerInfo(managerId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.Employees.Count}");

            foreach (EmployeeDto employee in managerDto.Employees)
            {
                sb.AppendLine($"   - {employee.FirstName} {employee.LastName} - ${employee.Salary}");
            }

            return sb.ToString();
        }
    }
}