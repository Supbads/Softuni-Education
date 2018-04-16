using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age, double averageGrade, string studentNumber, string currentCourse) : base(firstName, lastName, age, averageGrade, studentNumber, currentCourse)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
