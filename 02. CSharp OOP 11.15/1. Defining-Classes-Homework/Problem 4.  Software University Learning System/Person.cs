using System;
using Problem_3.PC_Catalog;

namespace Problem_4.Software_University_Learning_System
{
    abstract class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        protected Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public int Age
        {
            get { return age; }
            set
            {
                Validator.ValidateAgeInfo(value);
                age = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                Validator.ValidateStringInfo(value);
                lastName = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                Validator.ValidateStringInfo(value);
                firstName = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{1}, {2}{0}\tAge: {3}{0}",Environment.NewLine,firstName,lastName,age) ;
        }
    }
}
