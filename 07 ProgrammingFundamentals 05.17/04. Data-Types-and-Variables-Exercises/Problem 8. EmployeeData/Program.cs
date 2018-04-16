using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.EmployeeData
{
    class Program
    {
        static void Main(string[] args)
        {
            //First name: Amanda
            //    Last name: Jonson
            //Age: 27
            //Gender: f
            //    Personal ID: 8306112507
            //Unique Employee number: 27563571

            string employeeName = Console.ReadLine();
            string employeeSurname = Console.ReadLine();
            ushort employeeAge = ushort.Parse(Console.ReadLine());
            char employeeGender = Console.ReadLine().FirstOrDefault();
            long employeeId = long.Parse(Console.ReadLine());
            uint employeeNumber = uint.Parse(Console.ReadLine());

            Console.WriteLine("First name: {0}\nLast name: {1}",employeeName, employeeSurname);
            Console.WriteLine("Age: {0}\nGender: {1}", employeeAge, employeeGender);
            Console.WriteLine("Personal ID: {0}\nUnique Employee number: {1}", employeeId, employeeNumber);

        }
    }
}
