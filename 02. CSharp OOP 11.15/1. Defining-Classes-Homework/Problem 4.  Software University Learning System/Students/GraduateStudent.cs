using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class GraduateStudent : Student
    {
        public GraduateStudent(string firstName, string lastName, int age, double averageGrade, string studentNumber) : base(firstName, lastName, age, averageGrade, studentNumber)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
