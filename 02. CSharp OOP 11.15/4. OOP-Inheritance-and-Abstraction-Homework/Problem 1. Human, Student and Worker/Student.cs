using System;

namespace Problem_1.Human__Student_and_Worker
{
    class Student : Human
    {
        private string facultyNumber;
        private const int FacultyNumberMinLength = 5;
        private const int FacultyNumberMaxLength = 10;
        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Student faculty number cannot be null");
                }
                if (value.Length != value.Replace("[\\W_]+", "").Length)
                {
                    throw new ArgumentException("Student faculty number can only have letters and numbers");
                }
                if (value.Length < FacultyNumberMinLength || value.Length > FacultyNumberMaxLength)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Student faculty number can only be {0} to {1} characters long", FacultyNumberMinLength, FacultyNumberMaxLength));
                }
                facultyNumber = value;
            }
        }
    }
}
