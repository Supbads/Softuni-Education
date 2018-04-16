namespace _05.Company_Roster
{
    class Employee
    {
        //The name, salary, position and department are mandatory while the rest are optional.
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }

        public Employee(string name, decimal salary, string position, string department, string email = "n/a", int? age = -1)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = email;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:F2} {2} {3}", Name, Salary, Email, Age);
        }
    }
}
