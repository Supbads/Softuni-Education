using System;

namespace Problem_4.Software_University_Learning_System
{
    class CurrentStudent : Student
    {
        private string currentCourse;
        public CurrentStudent(string firstName, string lastName, int age, double averageGrade, string studentNumber,string currentCourse) : base(firstName, lastName, age, averageGrade, studentNumber)
        {
            this.CurrentCourse = currentCourse;
        }

        public string CurrentCourse
        {
            get { return currentCourse; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Current course cannot be null");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentException("Current course cannot be empty");
                }
                currentCourse = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\tCurrnet course: "+currentCourse+Environment.NewLine;
        }
    }
}
