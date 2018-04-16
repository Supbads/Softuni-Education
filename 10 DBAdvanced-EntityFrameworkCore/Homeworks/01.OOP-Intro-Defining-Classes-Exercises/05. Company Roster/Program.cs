using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var emplyeeArgs = Console.ReadLine().Split().ToArray();

                var name = emplyeeArgs[0];
                var salary = decimal.Parse(emplyeeArgs[1]);
                var position = emplyeeArgs[2];
                var department = emplyeeArgs[3];

                var employee = new Employee(name, salary, position, department);


                if (emplyeeArgs.Length == 6)
                {
                    var email = emplyeeArgs[4];
                    var age = int.Parse(emplyeeArgs[5]);

                    employee.Email = email;
                    employee.Age = age;
                }
                else if(emplyeeArgs.Length == 5)
                {
                    int age;
                    var mailOrAge = emplyeeArgs[4];
                    bool successfulParse = int.TryParse(mailOrAge, out age);

                    if (successfulParse) // 4th is age
                    {
                        employee.Age = age;
                    }
                    else //4th is email
                    {
                        employee.Email = mailOrAge;
                    }
                }

                employees.Add(employee);
            }

            //calculates the department with the highest average salary and 
            //prints for each employee in that department his name, salary, email and age –
            //sorted by salary in descending order. 

            decimal highestAverageSalary = -1;
            var bestDepartment = "";

            var groupedByDepartment = employees.GroupBy(e => e.Department);
            foreach (IGrouping<string, Employee> groups in groupedByDepartment)
            {
                var department = groups.Key;
                var averageSalary = groups.Average(s => s.Salary);

                if (averageSalary > highestAverageSalary)
                {
                    highestAverageSalary = averageSalary;
                    bestDepartment = department;
                }
            }

            Console.WriteLine("Highest Average Salary: " + bestDepartment);

            employees.Where(e => e.Department == bestDepartment)
                .OrderByDescending(e => e.Salary)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}