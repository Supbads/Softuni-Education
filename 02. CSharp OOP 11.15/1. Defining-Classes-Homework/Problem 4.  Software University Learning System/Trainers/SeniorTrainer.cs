using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {

        }

        public void DeleteCourse(string courseName)
        {
            Console.WriteLine("Course: "+ courseName+" has been deleted.");
        }

    }
}
