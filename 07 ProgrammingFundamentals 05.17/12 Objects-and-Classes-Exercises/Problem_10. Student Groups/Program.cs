using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Problem_10.Student_Groups
{
    public class Student
    {
        public Student(string name, string email, DateTime registrationDate)
        {
            this.Name = name;
            this.Email = email;
            this.RegistrationDate = registrationDate;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }
    }

    public class Town
    {
        public Town(string name, int seats)
        {
            this.Name = name;
            this.Seats = seats;
            this.Students = new List<Student>();
        }

        public string Name { get; set; }

        public int Seats { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Group
    {
        //public Group(Town town, List<Student> students)
        //{
        //    Town = town;
        //    Students = students;
        //}

        public Town Town { get; set; }

        public List<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input.Split(new[] { '>', '=' }, StringSplitOptions.RemoveEmptyEntries);

                string currentCity = tokens[0].Trim();
                string seatsAsString = tokens[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                int seats = int.Parse(seatsAsString);

                string studentsInput = Console.ReadLine();

                var town = new Town(currentCity, seats);

                while (!studentsInput.EndsWith("seats") && studentsInput != "End")
                {
                    var studentsData = studentsInput.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var studentName = studentsData[0] + " " + studentsData[1];
                    var studentEmail = studentsData[2];

                    DateTime studentRegistrationDate = DateTime.Now;
                    if (studentsData[3].IndexOf("-") == 1)
                    {
                        studentRegistrationDate =
                            DateTime.ParseExact(studentsData[3], "d-MMM-yyyy", NumberFormatInfo.InvariantInfo);
                    }
                    else if (studentsData[3].IndexOf("-") == 2)
                    {
                        studentRegistrationDate =
                            DateTime.ParseExact(studentsData[3], "dd-MMM-yyyy", NumberFormatInfo.InvariantInfo);
                    }
                    else
                    {
                        throw new FormatException();
                    }


                    var student = new Student(studentName, studentEmail, studentRegistrationDate);

                    town.Students.Add(student);

                    studentsInput = Console.ReadLine();
                }

                towns.Add(town);

                input = studentsInput;
            }


            var groups = DistributeStudentsIntoGroups(towns);

            Console.WriteLine("Created {0} groups in {1} towns:", groups.Count, towns.Count);

            foreach (var group in groups)
            {
                Console.WriteLine("{0} => {1}", group.Town.Name, string.Join(", ", group.Students.Select(x => x.Email)));
            }

        }


        static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            var groups = new List<Group>();

            foreach (var town in towns.OrderBy(t => t.Name))
            {
                IEnumerable<Student> students = town.Students.OrderBy(s => s.RegistrationDate).ThenBy(s => s.Name).ThenBy(s => s.Email);

                while (students.Any())
                {
                    var group = new Group();
                    group.Town = town;
                    group.Students = students.Take(group.Town.Seats).ToList();
                    students = students.Skip(group.Town.Seats);

                    groups.Add(group);
                }

            }

            return groups;
        }
    }
}
