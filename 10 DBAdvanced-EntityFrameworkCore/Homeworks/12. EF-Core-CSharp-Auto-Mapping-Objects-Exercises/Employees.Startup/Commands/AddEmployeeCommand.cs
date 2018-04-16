namespace Employees.Startup.Commands
{
    using Contracts;
    using Employees.DataModels;
    using Employees.Services.Contracts;

    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public AddEmployeeCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //<firstName> <lastName> <salary>
        public string Execute(params string[] parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var salary = decimal.Parse(parameters[2]);

            var employeeDto = new EmployeeDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            employeeService.AddEmployee(employeeDto);

            return $"Employee {employeeDto.FirstName} {employeeDto.LastName} added successfully";
        }
    }
}