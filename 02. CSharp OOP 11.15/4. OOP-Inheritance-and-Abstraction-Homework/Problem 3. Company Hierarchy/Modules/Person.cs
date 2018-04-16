using System;
using Problem_3.Company_Hierarchy.Interfaces;

namespace Problem_3.Company_Hierarchy.Modules
{
    class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private int id;

        public Person(string firstName, string lastName, int id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Person's first name cannot be null");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentOutOfRangeException("Person's first name cannot be empty");
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
                    throw new ArgumentNullException("Person's last name cannot be null");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentOutOfRangeException("Person's last name cannot be empty");
                }
                lastName = value;
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Person's id cannot be negative");
                }
                id = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} Id: {2}{3}",this.firstName,this.lastName,this.id,Environment.NewLine);
        }
    }
}
