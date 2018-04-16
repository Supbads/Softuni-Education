using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;
        public OnsiteStudent(string firstName, string lastName, int age, double averageGrade, string studentNumber, string currentCourse, int numberOfVisits)
            : base(firstName, lastName, age, averageGrade, studentNumber, currentCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }
        

        public int NumberOfVisits
        {
            get { return numberOfVisits; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Number of visits cannot be null");
                }
                if (value < 0)
                {
                    throw new ArgumentException("Number of visits cannot be negative");
                }
                numberOfVisits = value;
            }
        }

        public override string ToString()
        {
            return base.ToString()+"\tNumber of visits: "+numberOfVisits+Environment.NewLine;
        }
    }
}
