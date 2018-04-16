using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Human__Student_and_Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();
            studentsList.Add(new Student("Gosho", "Goshov", "4s591dw6g"));
            studentsList.Add(new Student("Pesho", "Peshev", "asd72fe51"));
            studentsList.Add(new Student("Tobleron", "Bonbon", "2A3gFd49s"));
            studentsList.Add(new Student("Motikarq", "Prezarejdane", "w51dof1e"));
            studentsList.Add(new Student("Georgi", "Georgiev", "ABCDEGHI"));
            studentsList.Add(new Student("Pisnami", "Veche", "s2156d1f"));
            
            List<Worker> workersList = new List<Worker>();
            workersList.Add(new Worker("Hei", "Rachichki", 6,561));
            workersList.Add(new Worker("Hei", "Gi",4,5616));
            workersList.Add(new Worker("Dve", "Te",21,3241));
            workersList.Add(new Worker("Pishat", "kodec",4,20));
            workersList.Add(new Worker("nai", "dobre",3,60));
            workersList.Add(new Worker("Hei", "Rachichki",6,9));
            workersList.Add(new Worker("Hei", "Rachichki",3,22));

            var sutdentsByFacultyNumber = studentsList.OrderBy(s => s.FacultyNumber);
            var workersByPPH = workersList.OrderByDescending(w => w.MoneyPerHour());

            List<Human> merged = sutdentsByFacultyNumber.Cast<Human>().ToList();
            merged.AddRange(workersByPPH);

            var sortedMerge = merged.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);
            //too lazy to override tostring , add break point <- here
        }
    }
}
