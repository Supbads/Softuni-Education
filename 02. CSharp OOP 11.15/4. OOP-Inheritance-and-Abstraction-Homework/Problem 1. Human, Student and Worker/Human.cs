using System;

namespace Problem_1.Human__Student_and_Worker
{
    abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("First name cannot be null");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentException("First name cannot be blank");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Last name cannot be null");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentException("Last name cannot be blank");
                }
                lastName = value;
            }
        }
    }
}
