using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class Trainer : Person
    {
        public Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {

        }

        public virtual void CreateCourse(string name)
        {
            Console.WriteLine("Course: "+name+ " has been created.");
        }
    }
}
