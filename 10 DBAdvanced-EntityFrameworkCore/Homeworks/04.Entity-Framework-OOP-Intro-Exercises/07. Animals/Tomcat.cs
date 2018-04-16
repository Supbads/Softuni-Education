using System;

namespace _07.Animals
{
    class Tomcat : Animal
    {
        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
            this.Gender = "Male";
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}