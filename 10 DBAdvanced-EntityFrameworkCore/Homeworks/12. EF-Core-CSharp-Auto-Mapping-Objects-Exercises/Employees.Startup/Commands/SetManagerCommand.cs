namespace Employees.Startup.Commands
{
    using Employees.Services.Contracts;
    using Contracts;

    public class SetManagerCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public SetManagerCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //<employeeId> <managerId> 
        public string Execute(params string[] parameters)
        {
            var employeeId = int.Parse(parameters[0]);
            var managerId = int.Parse(parameters[1]);

            var output = employeeService.SetManager(employeeId, managerId);

            return output;
        }
    }
}