using System;

namespace Problem_4.Software_University_Learning_System
{
    abstract class Student : Person
    {
        private double averageGrade;
        private string studentNumber;

        protected Student(string firstName, string lastName, int age, double averageGrade, string studentNumber) : base(firstName, lastName, age)
        {
            this.AverageGrade = averageGrade;
            this.StudentNumber = studentNumber;
        }

        public double AverageGrade
        {
            get { return averageGrade; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Average Grade cannot be null");
                }
                if (value < 2)
                {
                    throw new ArgumentException("Average grade cannot be less than 2");
                }
                averageGrade = value;
            }
        }

        public string StudentNumber
        {
            get { return studentNumber; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Student number cannot be null");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentException("Student number cannot be empty");
                }
                studentNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format("\tStudent number: {1}{0}\tAverage grade: {2:F2}{0}", Environment.NewLine,studentNumber,averageGrade );
        }
    }
}
