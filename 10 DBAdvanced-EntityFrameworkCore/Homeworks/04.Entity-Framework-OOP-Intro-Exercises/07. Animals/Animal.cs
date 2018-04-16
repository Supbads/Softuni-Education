using System;

namespace _07.Animals
{
    class Animal : ISoundProducable
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == "")
                {
                    throw new Exception("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Invalid input!");
                }

                this.age = value;
            }
        }
        public string Gender
        {
            get => this.gender;
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new Exception("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual void ProduceSound()
        {
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Name, this.Age, this.Gender);
        }

        public void Greet()
        {
            Console.WriteLine(this.GetType().Name);
            Console.WriteLine(this.ToString());
            this.ProduceSound();
        }
    }
}