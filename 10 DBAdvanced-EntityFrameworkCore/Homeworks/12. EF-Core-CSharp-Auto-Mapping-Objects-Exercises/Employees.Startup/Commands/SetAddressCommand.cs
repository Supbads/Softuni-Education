namespace Employees.Startup.Commands
{
    using System;
    using Employees.Services.Contracts;
    using Contracts;

    class SetAddressCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public SetAddressCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        
        public string Execute(params string[] parameters)
        {
            var id = int.Parse(parameters[0]);
            var address = parameters[1];

            var employee = employeeService.SetAddress(id, address);

            return $"Employee {employee.FirstName} {employee.LastName} has updated his address.";
        }
    }
}
