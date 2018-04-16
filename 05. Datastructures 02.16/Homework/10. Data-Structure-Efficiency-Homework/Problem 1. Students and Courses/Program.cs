namespace Problem_1.Students_and_Courses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            const string Path = @"../../students.txt";

            var courses = new SortedDictionary<string, SortedSet<Student>>();

            using (StreamReader reader = new StreamReader(Path))
            {
                var input = reader.ReadLine();

                while (input != null)
                {
                    var tokens = input.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                    var course = tokens[2];
                    var student = new Student
                    {
                        FirstName = tokens[0],
                        LastName = tokens[1]
                    };

                    if (!courses.ContainsKey(course))
                    {
                        courses[course] = new SortedSet<Student>();
                    }

                    courses[course].Add(student);
                    input = reader.ReadLine();
                }
            }

            foreach (var courseAndStudents in courses)
            {
                var students = string.Join(", ", courseAndStudents.Value);
                Console.WriteLine(courseAndStudents.Key + ": " + students);
            }
        }
    }
}
