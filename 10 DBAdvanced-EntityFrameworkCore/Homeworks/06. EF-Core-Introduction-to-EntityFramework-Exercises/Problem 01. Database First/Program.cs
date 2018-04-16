using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace P02_DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProblemOne();     // Employees Full Information
            //ProblemTwo();     // Employees with Salary Over 50 000
            //ProblemThree();   // Employees from Research and Development
            //ProblemFour();    // Adding a New Address and Updating Employee
            //ProblemFive();    // Employees and Projects
            //ProblemSix();     // Addresses by Town
            //ProblemSeven();   // Employee 147
            //ProblemEight();   // Departments with More Than 5 Employees
            //ProblemNine();    // Find Latest 10 Projects
            //ProblemTen();     // Increase Salaries
            //ProblemEleven();  // Find Employees by First Name Starting With "Sa"
            //ProblemTwelve();  // Delete Project by Id



        }

        public static void ProblemOne()
        {
            /*
             Extract all employees and print their
             first, last and middle name, their job title and salary, rounded to 2 symbols after the decimal separator, 
             all of those separated with a space.
             Order them by employee id.          
             */
            using (var softuni = new SoftUniContext())
            {
                var employees = softuni.Employees
                    .Select(e => new
                    {
                        e.EmployeeId,
                        e.FirstName,
                        e.MiddleName,
                        e.LastName,
                        e.Salary,
                        e.JobTitle
                    })
                    .OrderBy(e => e.EmployeeId);

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
                }
            }
        }

        public static void ProblemTwo()
        {
            /*
             Your task is to extract all employees with salary over 50000. 
             Return only the first names of those employees, ordered alphabetically.
             */

            using (var connection = new SoftUniContext())
            {
                var employees = connection.Employees
                    .Where(e => e.Salary > 50_000)
                    .Select(e => new
                    {
                        e.FirstName,
                    })
                    .OrderBy(e => e.FirstName)
                    .ToList();

                employees.ForEach(e => Console.WriteLine(e.FirstName));

            }
        }

        public static void ProblemThree()
        {
            /*
            Extract all employees from the Research and Development department.
            Order them by salary(in ascending order), then by first name(in descending order). 
            Print only their first name, last name, department name and salary in the format shown below:
            Gigi Matthew from Research and Development - $40900.00
            */

            using (var connection = new SoftUniContext())
            {
                var employees = connection.Employees.Where(e => e.Department.Name == "Research and Development").Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary,
                    DepartmentName = e.Department.Name
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

                employees.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}"));
            }
        }

        public static void ProblemFour()
        {
            /*
            Create a new address with text "Vitoshka 15" and TownId 4.
            Set that address to the employee with last name "Nakov".
            Then order by descending all the employees by their Address’ Id, take 10 rows and from them, take the AddressText.
            Print the results each on a new line:
             */
            var address = new Address();
            address.TownId = 4;
            address.AddressText = "Vitoshka 15";

            using (var connection = new SoftUniContext())
            {
                var employeeLastNameNakov = connection.Employees.FirstOrDefault(e => e.LastName == "Nakov");
                employeeLastNameNakov.AddressId = address.AddressId;
                employeeLastNameNakov.Address = address;

                connection.SaveChanges();

                var employees = connection.Employees
                    .OrderByDescending(e => e.AddressId)
                    .Take(10)
                    .Select(e => new
                    {
                        e.Address.AddressText
                    });

                foreach (var emp in employees)
                {
                    Console.WriteLine(emp.AddressText);
                }

            }

        }

        public static void ProblemFive()
        {
            /*
            Find the first 30 employees who have projects started in the time period 2001 - 2003 (inclusive).
            Print each employee's first name, last name and manager’s first name and last name and each of their projects' name,
            start date, end date.
            If a project has no end date, print "not finished" instead.
            
            Guy Gilbert – Manager: Jo
            --Half-Finger Gloves - 6/1/2002 12:00:00 AM - 6/1/2003 12:00:00 AM

            Use date format: "M/d/yyyy h:mm:ss tt".
             */

            using (var connection = new SoftUniContext())
            {
                var employees = connection.Employees.Include(e => e.Manager)
                    .Include(e => e.EmployeeProjects)
                    .ThenInclude(p => p.Project)
                    .Where(e => e.EmployeeProjects.Any(p => p.Project.StartDate.Year > 2000 && p.Project.StartDate.Year < 2004))
                    .Take(30)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        ManagerFirstName = e.Manager.FirstName,
                        ManagerLastName = e.Manager.LastName,
                        e.EmployeeProjects,
                    })
                    .ToList();
               

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} – Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                    foreach (var employeeProject in employee.EmployeeProjects)
                    {
                        string format = "M/d/yyyy h:mm:ss tt";

                        var project = employeeProject.Project;

                        string startDateFormatted = project.StartDate.ToString(format, CultureInfo.InvariantCulture);
                        string endDate = project.EndDate.ToString();

                        if (string.IsNullOrWhiteSpace(endDate))
                        {
                            endDate = "not finished";
                        }
                        else
                        {
                            endDate = project.EndDate.Value.ToString(format, CultureInfo.InvariantCulture);
                        }

                        Console.WriteLine($"--{project.Name} - {startDateFormatted} - {endDate}");

                    }
                }

            }

        }

        public static void ProblemSix()
        {
            /*
             Find all addresses, ordered by the number of employees who live there (descending), 
             then by town name (ascending), and finally by address text (ascending).
             Take only the first 10 addresses.
             For each address print it in the format "<AddressText>, <TownName> - <EmployeeCount> employees":
             */

            using (var connection = new SoftUniContext())
            {
                var addresses = connection.Addresses
                    .Include(a => a.Town)
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .Select(a => new
                    {
                        a.AddressText,
                        TownName = a.Town.Name,
                        EmployeeCount = a.Employees.Count
                    })
                    .ToList();

                foreach (var address in addresses)
                {
                    Console.WriteLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");

                }

            }
        }

        public static void ProblemSeven()
        {
            /*
            Get the employee with id 147. Print only his/her first name, last name, job title and projects (print only their names).
            The projects should be ordered by name (ascending). Format of the output:     
            Linda Randall - Production Technician
            */

            using (var connection = new SoftUniContext())
            {
                var employee = connection.Employees.Include(e => e.EmployeeProjects).FirstOrDefault(e => e.EmployeeId == 147);
                var projects = connection.Projects;

                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                var allProjects = new List<Project>();

                foreach (var employeeProject in employee.EmployeeProjects)
                {
                    var currentProject = projects.FirstOrDefault(p => p.ProjectId == employeeProject.ProjectId);
                    allProjects.Add(currentProject);
                }

                foreach (var project in allProjects.OrderBy(p => p.Name))
                {
                    Console.WriteLine(project.Name);
                }

            }

        }

        public static void ProblemEight()
        {
            /*
            Find all departments with more than 5 employees. Order them by employee count (ascending). 
            For each department, print the department name and the manager’s first and last name on the first row.
            Then print the first name, the last name and the job title of every employee on a new row. 
            Then, print 10 dashes before the next department ("----------"). 
            Order the employees by first name (ascending), then by last name (ascending). 
            */

            using (var connection = new SoftUniContext())
            {
                var departments = connection.Departments
                    .Include(d => d.Manager)
                    .Include(d => d.Employees)
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .ToList();

                foreach (var department in departments)
                {
                    Console.WriteLine($"{department.Name} – {department.Manager.FirstName} {department.Manager.LastName}");

                    foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                    {
                        Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                    }

                    Console.WriteLine(new string('-', 10));
                }

            }

        }

        public static void ProblemNine()
        {
            /*
            Write a program that prints information about the last 10 started projects.
            Sort them by name lexicographically and print their name, description and start date, each on a new row.
            Format of the output:
            */

            using (var connection = new SoftUniContext())
            {
                var projects = connection.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .OrderBy(p => p.Name);


                string format = "M/d/yyyy h:mm:ss tt";

                foreach (var project in projects)
                {
                    Console.WriteLine($"{project.Name}");
                    Console.WriteLine($"{project.Description}");

                    var formattedStartDate = project.StartDate.ToString(format, CultureInfo.InvariantCulture);
                    Console.WriteLine($"{formattedStartDate}");

                }

            }

        }

        public static void ProblemTen()
        {
            /*
             increase salaries of all employees that are in the Engineering, Tool Design, Marketing or Information Services department
             by 12%.
             print first name, last name and salary (2 symbols after the decimal separator) for those employees whose salary was increased.
             Order them by first name (ascending), then by last name (ascending). 
             Format of the output:             
             */

            using (var connection = new SoftUniContext())
            {
                connection.Employees
                    .Include(e => e.Department)
                    .Where(e => 
                        e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" || 
                        e.Department.Name == "Information Services" ||
                        e.Department.Name == "Marketing")
                    .ToList()
                    .ForEach(e => e.Salary*=1.12m);

                connection.SaveChanges();

                var employees = connection.Employees
                    .Include(e => e.Department)
                    .Where(e =>
                        e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Information Services" ||
                        e.Department.Name == "Marketing")
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();


                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
                }

            }

        }

        public static void ProblemEleven()
        {
            /*
            Write a program that finds all employees whose first name starts with "Sa".
            Print their first, last name, their job title and salary in the format given in the example below.
            Order them by first name, then by last name (ascending).
            */

            using (var connection = new SoftUniContext())
            {
                var employees = connection.Employees
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName);

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
                }

            }

        }

        public static void ProblemTwelve()
        {
            /*
            Let's delete the project with id 2. Then, take 10 projects and print their names on the console, each on a new line.
            Remember to restore your database after this task.
            */

            using (var connection = new SoftUniContext())
            {
                var projectToRemove = connection.Projects.Find(2);
                
                var employeesProjects = connection.EmployeesProjects;
                var referencedProjects = employeesProjects.Where(p => p.ProjectId == 2).ToList();

                //remove all references from the relational table
                employeesProjects.RemoveRange(referencedProjects);

                //remove the project itself
                connection.Remove(projectToRemove);

                connection.SaveChanges();

                connection.Projects.Take(10).ToList().ForEach(p => Console.WriteLine(p.Name));

            }

        }

        private static void ProblemThirdteen()
        {
            using (var connection = new SoftUniContext())
            {
                Console.WriteLine("Enter a town name: ");
                var townName = Console.ReadLine();

                var town = connection
                    .Towns
                    .Include(t => t.Addresses)
                    .SingleOrDefault(t => t.Name == townName);

                var adressCount = 0;
                if (town != null)
                {
                    adressCount = town.Addresses.Count;

                    connection
                        .Employees
                        .Where(e => e.AddressId != null && town.Addresses.Any(a => a.AddressId == e.AddressId))
                        .ToList()
                        .ForEach(e => e.Address = null);

                    connection.SaveChanges();

                    connection
                        .Addresses
                        .RemoveRange(town.Addresses);

                    connection.Towns.Remove(town);

                    connection.SaveChanges();
                }

                Console.WriteLine($"{adressCount} address in {townName} was deleted");
            }
        }

    }
}