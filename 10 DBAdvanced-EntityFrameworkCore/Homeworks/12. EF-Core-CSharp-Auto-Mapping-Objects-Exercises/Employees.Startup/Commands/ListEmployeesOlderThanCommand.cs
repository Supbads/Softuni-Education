namespace Employees.Startup.Commands
{
    using Employees.Services.Contracts;
    using Contracts;
    using System.Text;

    class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public ListEmployeesOlderThanCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] parameters)
        {
            int age = int.Parse(parameters[0]);

            var employees = employeeService.EmployeesOlderThan(age);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullName} - ${employee.Salary} - Manager: {employee.ManagerFullName ?? "[No Manager]"}");
            }

            return sb.ToString();
        }
    }
}