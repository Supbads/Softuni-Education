namespace Employees.Startup.Commands
{
    using System;
    using Contracts;
    using Employees.Services.Contracts;

    class SetBirthdayCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public SetBirthdayCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //<employeeId> <date: "dd-MM-yyyy"> 
        public string Execute(params string[] parameters)
        {
            var employeeId = int.Parse(parameters[0]);
            var date = parameters[1];

            var dateFormat = "dd-MM-yyyy";

            var parsedDate = DateTime.ParseExact(date, dateFormat, null);

            var employee = employeeService.SetBirthDay(employeeId, parsedDate);

            return $"Employee {employee.FirstName} {employee.LastName} has updated his birthday successfully.";
        }
    }
}