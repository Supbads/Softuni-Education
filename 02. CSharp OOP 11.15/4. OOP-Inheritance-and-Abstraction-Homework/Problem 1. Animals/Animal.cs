using System;

namespace Problem_1.Animals
{
    abstract class Animal : ISoundProduceable
    {
        private string name;
        private int age;
        private string gender;
        
        protected Animal(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Animal name cannot be null");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentException("Animal name cannot be empty");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (age < 0)
                {
                    throw new ArgumentOutOfRangeException("Animal age cannot be negative");
                }
                age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Animal gender cannot be null");
                }
                if (value != "Male" || value != "Female")
                {
                    throw new ArgumentException("Animal gender can only be Female or Male");
                }
                gender = value;
            }
        }

        public virtual void ProduceSound()
        {
        }
    }
}
