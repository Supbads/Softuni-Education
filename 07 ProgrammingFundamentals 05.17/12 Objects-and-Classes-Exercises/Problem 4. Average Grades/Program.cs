using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4.Average_Grades
{
    public class Student
    {
        public Student(string name)
        {
            this.Name = name;
            this.Grades = new List<double>();
        }


        public List<double> Grades { get; set; }
        public string Name { get; set; }
        public double averageGrade()
        {
            return this.Grades.Average();
        }

        public override bool Equals(object obj)
        {
            if (obj is Student && obj != null)
            {
                Student other = (Student)obj;
                return other.Name == this.Name;
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                var studentName = tokens[0];
                Student currentStudent = new Student(studentName);
                
                for (int j = 1; j < tokens.Length; j++)
                {
                    double currentGrade = double.Parse(tokens[j]);
                    currentStudent.Grades.Add(currentGrade);
                }
                
                studentsList.Add(currentStudent);
            }

            foreach (var student in studentsList.Where(y => y.averageGrade()>= 5.00).OrderBy(x => x.Name).ThenByDescending(x => x.averageGrade()))
            {
                Console.WriteLine("{0} -> {1:F2}", student.Name, student.averageGrade());
            }
        }
    }
}