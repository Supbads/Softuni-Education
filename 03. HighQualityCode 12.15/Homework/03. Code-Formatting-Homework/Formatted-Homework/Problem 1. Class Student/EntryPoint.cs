namespace Problem_1.Class_Student
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The following class is a practice for sorting
    /// collections with lambda expressions and linq queries
    /// <param name="query">Holds the filtered/ordered/sorted
    /// collection made with linq
    /// </param>
    /// <param name="lambda">Holds the filtered/ordered/sorted
    /// collection made with lambda expression</param>
    /// </summary>
    class EntryPoint
    {
        static void Main()
        {
            var students = CreateStudentsCollection();

            SortStudentsByGroup(students);

            SortStudentsByNames(students);

            SortStudentsByAge(students);

            StudentsByNamesDescending(students);

            FilterStudentsByEmailDomain(students);

            FilterStudentsByPhone(students);

            FilterStudentsWithAPerfectGrade(students);

            FilterStudentsWithTwoOrMoreBadGrades(students);

            FilterStudentsEnrolledIn2014(students);

            GroupStudentsByGroupName(students);

            JoinStudentsWithSpecialties(students);
        }

        private static void JoinStudentsWithSpecialties(List<Student> students)
        {
            Console.WriteLine("Problem 12. Students Joined to Specialties");
            var specialitiesFacNums = new List<StudentSpecialties>
            {
                new StudentSpecialties("Web Developer", 900020915),
                new StudentSpecialties("Web Developer", 901020915),
                new StudentSpecialties("PHP Developer", 90561486),
                new StudentSpecialties("PHP Developer", 924030914),
                new StudentSpecialties("QA Engineer", 024056914)
            };

            var jonedData =
                from student in students
                orderby student.FirstName ascending, student.LastName ascending
                join speciality in specialitiesFacNums on student.FacultyNumber equals speciality.FacultyNumber
                select new {student.FirstName, student.LastName, student.FacultyNumber, speciality.Speciality};
            Print(jonedData);
            Console.WriteLine();
        }

        private static void GroupStudentsByGroupName(List<Student> students)
        {
            Console.WriteLine("Problem 11. Students by Groups");

            var query =
                from student in students
                group student by student.GroupName;

            foreach (var studentGroup in query)
            {
                Console.WriteLine(studentGroup.Key);
                Print(studentGroup);
            }

            Console.WriteLine();
        }

        private static void FilterStudentsEnrolledIn2014(List<Student> students)
        {
            Console.WriteLine("Problem 10. Students Enrolled in 2014");

            var query =
                from student in students
                where student.FacultyNumber%100 == 14
                //or if it's a string EndsWith()
                select new { student.FirstName, student.LastName, student.Marks };
            Print(query);

            Console.WriteLine();
        }

        private static void FilterStudentsWithTwoOrMoreBadGrades(List<Student> students)
        {
            Console.WriteLine("Problem 9. Weak Students");

            var lambda = students.Where(st => st.Marks.Count(x => x == 2) >= 2);

            Print(lambda);
            Console.WriteLine();
        }

        private static void FilterStudentsWithAPerfectGrade(List<Student> students)
        {
            Console.WriteLine("Problem 8. Excellent Students");

            var query =
                from student in students
                where (student.Marks.Max() == 6)
                select student;

            var lambda =
                students.Where(st => st.Marks.Max() == 6)
                .Select(st => new {Fullname = string.Join(" ", st.FirstName, st.LastName), Marks = string.Join(" ", st.Marks)});

            Print(lambda);
            Console.WriteLine();
        }

        private static void FilterStudentsByPhone(List<Student> students)
        {
            Console.WriteLine("Problem 7. Filter Students by Phone");
            var query =
                from student in students
                where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2")
                select student;
            Print(query);
            Console.WriteLine();
        }

        private static void FilterStudentsByEmailDomain(List<Student> students)
        {
            const string allowedDomain = "@abv.bg";
            Console.WriteLine("Problem 6. Filter Students by Email Domain");

            var withQuery =
                from student in students
                where student.Email.Contains(allowedDomain)
                select new {student.FirstName, student.LastName, student.Email};

            var withLambda = students.Where(x => x.Email.Contains(allowedDomain)).Select(x => new { x.FirstName, x.LastName, x.Email });
            Print(withLambda);
            Console.WriteLine();
        }

        private static void StudentsByNamesDescending(List<Student> students)
        {
            Console.WriteLine("Problem 5. Sort Students");

            var query =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            var lambda = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

            Console.WriteLine("Linq:");
            Print(query);

            Console.WriteLine("lambda:");
            Print(lambda);
            Console.WriteLine();
        }

        private static void SortStudentsByAge(List<Student> students)
        {
            const int studentMinAge = 18;
            const int studentMaxAge = 24;

            Console.WriteLine("Problem 4. Students by Age");
            var query =
                from student in students
                where student.Age >= studentMinAge && student.Age <= studentMaxAge
                select new {student.FirstName, student.LastName, student.Age};

            Print(query);
            Console.WriteLine();
        }

        private static void SortStudentsByNames(List<Student> students)
        {
            Console.WriteLine("Problem 3. Students by First and Last Name");

            var query =
                from student in students
                where (student.FirstName.CompareTo(student.LastName) < 0)
                select student;

            var lambda = students.Where(x => x.FirstName.CompareTo(x.LastName) < 0);

            Print(query);
            Console.WriteLine();
        }

        private static void SortStudentsByGroup(List<Student> students)
        {
            Console.WriteLine("Problem 2. Students by Group");

            var lambda = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);

            var query =
                from st in students
                where st.GroupNumber == 2
                orderby st.FirstName
                select st;

            Print(query);
            Console.WriteLine();
        }

        private static List<Student> CreateStudentsCollection()
        {
            Console.WriteLine("Problem 1. Class Student");

            var students = InitializeStudents();
            Console.WriteLine();
            return students;
        }

        private static List<Student> InitializeStudents()
        {
            var students = new List<Student>
            {
                new Student("Nikolay", "Nikolov", 26, 900020915, "0955451887", "randomMail@mail.bg",
                    new List<int> {2, 3, 4, 6, 6, 6}, 2, "Alpha"),
                new Student("Tehno", "Mikz", 20, 901020915, "5274576540", "ayylmao@abv.bg", new List<int> {6, 6, 3, 5}, 1,
                    "Beta"),
                new Student("Mitko", "Kalaidjiev", 55, 90561486, "156164181", "ednoParchence@iSi.Tam", new List<int> {7, 8}, 1,
                    "Alpha"),
                new Student("Filip", "Kolev", 21, 924030914, "359 897434561", "filip.f@ght.gh", new List<int> {2, 6, 6, 6}, 2,
                    "Alpha"),
                new Student("Asen", "Tahchiski", 22, 024056914, "359 845632345", "asen@hotmail.com", new List<int> {6, 6, 6, 6},
                    2, "Beta")
            };
            return students;
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
