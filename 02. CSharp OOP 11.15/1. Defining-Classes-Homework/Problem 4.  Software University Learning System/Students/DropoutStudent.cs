using System;

namespace Problem_4.Software_University_Learning_System
{
    class DropoutStudent : Student
    {
        private string dropoutReason;
        public DropoutStudent(string firstName, string lastName, int age, double averageGrade, string studentNumber, string dropoutReason) : base(firstName, lastName, age, averageGrade, studentNumber)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get { return dropoutReason; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Dropout reason cannot be null");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentException("Dropout reason cannot be empty");
                }
                dropoutReason = value;
            }
        }

        public void Reapply()
        {
            string message = base.ToString();
            message += string.Format("\tDropout reason: {0}{1}", this.dropoutReason, Environment.NewLine);
            Console.WriteLine(message);
        }
    }
}
