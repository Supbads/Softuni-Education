using System;
using System.Collections.Generic;
using Problem_3.Company_Hierarchy.Modules;

namespace Problem_3.Company_Hierarchy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Manager manager1 = new Manager("Manager1", "Manager1 Last name", 0000000001, 123m, "Accounting");
                Manager manager2 = new Manager("Manager2", "Manager2 Last name", 0000000002, 3124m, "Sales");
                Manager manager3 = new Manager("Manager3", "Manager3 Last name", 0000000003, 1423m, "Marketing");

                SalesEmployee salesEmployee1 = new SalesEmployee("SalesEmployee1", "SalesEmployee1 Last name",
                    0000000004, 512m, "Accounting");
                SalesEmployee salesEmployee2 = new SalesEmployee("SalesEmployee2", "SalesEmployee2 Last name",
                    0000000005, 1000m, "Production");
                SalesEmployee salesEmployee3 = new SalesEmployee("SalesEmployee3", "SalesEmployee3 Last name",
                    0000000006, 513m, "Marketing");

                Developer developer1 = new Developer("Developer1", "Developer1 Last name", 0000000007, 4200m,
                    "Marketing");
                Developer developer2 = new Developer("Developer2", "Developer2 Last name", 0000000008, 322m, "Accounting");
                Developer developer3 = new Developer("Developer3", "Developer3 Last name", 0000000009, 720m,
                    "Production");

                manager1.AddEmployees(new HashSet<Employee> { salesEmployee1, salesEmployee2 , developer1});

                Sale sale = new Sale("graphic card", DateTime.Now, 220m);

                Project project1 = new Project("OOP", DateTime.Now, "OOP course");
                Project project2 = new Project("Java", DateTime.Today, "Java Fundamentals");

                manager1.AddEmployees(new HashSet<Employee> { salesEmployee1, developer3 });

                salesEmployee1.AddSales(new HashSet<Sale> { sale });
                developer1.AddProjects(new HashSet<Project> { project1, project2 });
                developer2.AddProjects(new HashSet<Project> { project2 });
                developer3.AddProjects(new HashSet<Project> { project1 });

                IList<Employee> employees = new List<Employee>
            {
                manager1,
                manager2,
                manager3,
                salesEmployee1,
                salesEmployee2,
                salesEmployee3,
                developer1,
                developer2,
                developer3
            };

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }
    }
}

