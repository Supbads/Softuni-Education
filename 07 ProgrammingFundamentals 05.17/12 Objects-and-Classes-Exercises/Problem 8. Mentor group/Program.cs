using System;
using System.Collections.Generic;  //ne raboti !!!
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MentorGroup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        SortedDictionary<string, Student> students = new SortedDictionary<string, Student>();

        while (input != "end of dates")
        {
            string[] studentInfo = input.Split(' ');
            string name = studentInfo[0];
            List<DateTime> dates = new List<DateTime>();

            if (studentInfo.Length > 1)
            {


                string[] dateSeq = studentInfo[1].Split(',');
                

                for (int i = 0; i < dateSeq.Length; i++)
                {
                    DateTime currDate = DateTime.ParseExact(dateSeq[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dates.Add(currDate);
                }
            }

            Student student = new Student();
            student.Name = name;

            if (!students.ContainsKey(name))
            {
                students.Add(name, student);
                student.Attendency = dates;
            }
            else
            {
                students[name].Attendency.AddRange(dates);
            }

            input = Console.ReadLine();
        }

        string secondInput = Console.ReadLine();

        while (secondInput != "end of comments")
        {
            string[] commentsInfo = secondInput.Split('-');
            string name = commentsInfo[0];
            string comment = commentsInfo[1];
            List<string> comments = new List<string>();
            comments.Add(comment);

            if (students.ContainsKey(name))
            {
                if (students[name].Comments != null)
                {
                    students[name].Comments.AddRange(comments);
                }
                else
                {
                    students[name].Comments = comments;
                }
            }

            secondInput = Console.ReadLine();
        }

        foreach (var entry in students)
        {
            Console.WriteLine("{0}", entry.Key);
            Console.WriteLine("Comments:");

            if (entry.Value.Comments != null)
            {
                foreach (var comment in entry.Value.Comments)
                {
                    Console.WriteLine("- {0}", comment);
                }
            }

            Console.WriteLine("Dates attended:");

            foreach (var date in entry.Value.Attendency.OrderBy(d => d))
            {
                Console.WriteLine("-- {0:dd/MM/yyyy}", date);
            }
        }
    }
}

public class Student
{
    public string Name { get; set; }
    public List<DateTime> Attendency { get; set; }
    public List<string> Comments { get; set; }
}