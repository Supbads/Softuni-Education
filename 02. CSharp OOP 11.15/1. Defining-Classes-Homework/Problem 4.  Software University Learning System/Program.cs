using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class Program
    {
        static void Main(string[] args)
        {
           
            IList<Person> data = new List<Person>();
            data.Add(new OnlineStudent("Fill", "Kolev", 25, 6.01, "000001", "Advanced F#"));
            data.Add(new OnsiteStudent("Royal", "Royal", 24, 2.5, "000002", "Advanced R#", 7));
            data.Add(new Trainer("Svetlin", "Nakov", 32));
            data.Add(new DropoutStudent("Gosho", "Pesho", 18, 5.25, "000003", "Bachka choveka i nqma vreme"));
            data.Add(new CurrentStudent("Todor", "Manolov", 22, 4.33, "000005", "Algoritmi"));
            data.Add(new CurrentStudent("Someone", "Help", 26, 5.82, "000008", "Advanced Pesho#"));
            data.Add(new CurrentStudent("Pesho", "Gosho", 26, 3.48, "000008", "Advanced Pesho#"));
            data.Add(new GraduateStudent("Traicho", "Georgiev", 17, 3.99, "00010"));
            data.Add(new JuniorTrainer("Dobri", "Chintolov", 30));
            data.Add(new SeniorTrainer("Trener", "Zdrav", 28));

            var sortedDataByCurrentStudentsByGrades =
                data.Where(t => t.GetType() == typeof (CurrentStudent))
                    .Select(s => (CurrentStudent) s)
                    .OrderBy(p => p.AverageGrade)
                    .ToList();
                    //.ForEach(p => Console.WriteLine(p.ToString()));  //why won't you work
            foreach (CurrentStudent person in sortedDataByCurrentStudentsByGrades)
            {
                Console.WriteLine(person.ToString());
            }
            JuniorTrainer jt = (JuniorTrainer)data[8];
            jt.CreateCourse("Slab course");
            SeniorTrainer st = (SeniorTrainer) data[9];
            st.DeleteCourse("Slab course");
            st.CreateCourse("Po-silen course");

            //var dataByTrainers =
            //    data.Where(t=> t.GetType()== typeof(Trainer)).Select()



        }
    }
}
