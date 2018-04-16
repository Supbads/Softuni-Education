using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1.Class_Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problem 1.   Class Student");
            var students = new List<Student>
            { 
                new Student("Nikolay","Nikolov",26,900020915,"0955451887","randomMail@mail.bg",new List<int>{2,3,4,6,6,6} ,2,"Alpha"),
                new Student("Tehno","Mikz",20,901020915,"5274576540","ayylmao@abv.bg",new List<int>{6,6,3,5},1,"Beta"),
                new Student("Mitko","Kalaidjiev",55,90561486,"156164181","ednoParchence@iSi.Tam",new List<int>{7,8},1,"Alpha"),
                new Student("Filip", "Kolev",21,924030914,"359 897434561","filip.f@ght.gh",new List<int> {2, 6, 6, 6},2,"Alpha"),
                new Student("Asen", "Tahchiski",22,024056914,"359 845632345","asen@hotmail.com",new List<int> {6, 6, 6, 6},2,"Beta")
            };
            Console.WriteLine();
            Console.WriteLine("Problem 2.   Students by Group");
            var group = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);
            var groupTwoStudents =
                from st in students
                where st.GroupNumber == 2
                orderby st.FirstName
                select st;
            Print(groupTwoStudents);
            Console.WriteLine();
            Console.WriteLine("Problem 3.	Students by First and Last Name");
            var group2 =
                from student in students
                where (student.FirstName.CompareTo(student.LastName) < 0)
                select student;
            var problem3Students = students.Where(x => x.FirstName.CompareTo(x.LastName) < 0);
            Print(group2);
            Console.WriteLine();
            Console.WriteLine("Problem 4.	Students by Age");
            var problem4Query =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select new { student.FirstName, student.LastName,student.Age };

            Print(problem4Query);
            Console.WriteLine();
            Console.WriteLine("Problem 5.	Sort Students");
            var problem5Query =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;
            var problem5 = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);
            Console.WriteLine("Linq:");
            Print(problem5Query);
            Console.WriteLine("Ext:");
            Print(problem5);
            Console.WriteLine();
            Console.WriteLine("Problem 6.	Filter Students by Email Domain");
            var problem6Query =
                from student in students
                where student.Email.Contains("@abv.bg")
                select new {student.FirstName,student.LastName,student.Email};
            var problem6 = students.Where(x => x.Email.Contains("@abv.bg")).Select(x => new {x.FirstName,x.LastName,x.Email });
            Print(problem6);
            Console.WriteLine();
            Console.WriteLine("Problem 7.	Filter Students by Phone");
            var problem7Query =
                from student in students
                where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2")
                select student;
            Print(problem7Query);
            Console.WriteLine();
            Console.WriteLine("Problem 8.	Excellent Students");
            var problem8 =
                from student in students
                where (student.Marks.Max() == 6)
                select student;
            var problem8Linq =
                students.Where(st => st.Marks.Max() == 6).Select(st => new { Fullname = string.Join(" ", st.FirstName, st.LastName), Marks = string.Join(" ", st.Marks) });
            Print(problem8Linq);
            Console.WriteLine();
            Console.WriteLine("Problem 9.	Weak Students");
            var problem9Ext = students.Where(st => st.Marks.Count(x => x == 2) == 2);
            Print(problem9Ext);
            Console.WriteLine();
            Console.WriteLine("Problem 10.	Students Enrolled in 2014");
            var problem10Linq =
                from student in students
                where student.FacultyNumber % 100 == 14  //or if it's a string EndsWith()
                select new { student.FirstName , student.LastName,student.Marks};
            Console.WriteLine();
            Console.WriteLine("Problem 11.  Students by Groups");
            var problem11Query =
                from student in students
                group student by student.GroupName;
            foreach (var studentGroup in problem11Query)
            {
                Console.WriteLine(studentGroup.Key);
                Print(studentGroup);
            }
            Console.WriteLine();
            Console.WriteLine("Problem 12.  Students Joined to Specialties");
            var specialitiesFacNums = new List<StudentSpecialties>
		        {
			        new StudentSpecialties("Web Developer",900020915),
			        new StudentSpecialties("Web Developer",901020915),
			        new StudentSpecialties("PHP Developer",90561486),
			        new StudentSpecialties("PHP Developer",924030914),
			        new StudentSpecialties("QA Engineer",024056914)
		        };

            var jonedData =
               from student in students
               orderby student.FirstName ascending, student.LastName ascending
               join speciality in specialitiesFacNums on student.FacultyNumber equals speciality.FacultyNumber
               select new { student.FirstName, student.LastName, student.FacultyNumber, speciality.Speciality };
            Print(jonedData);
            Console.WriteLine();
        }
        static void Print(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
