namespace Employees.DataModels
{
    public class EmployeeWorkDto
    {
        public int Id { get; set; }

        public string EmployeeFullName { get; set; }

        public decimal Salary { get; set; }

        public string ManagerFullName { get; set; }
    }
}