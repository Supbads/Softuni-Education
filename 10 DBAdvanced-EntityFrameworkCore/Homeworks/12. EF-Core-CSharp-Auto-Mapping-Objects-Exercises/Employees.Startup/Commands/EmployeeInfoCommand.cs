namespace Employees.Startup.Commands
{
    using Contracts;
    using Employees.Services.Contracts;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public EmployeeInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] parameters)
        {
            var employeeId = int.Parse(parameters[0]);

            var employeeDto = employeeService.EmployeeInfo(employeeId);

            return $"ID: {employeeId} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}";
        }
    }
}