using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            If you receive an input for the gender of a Tomcat or a Kitten, ignore it but create the animal             
            */
            var animals = new List<Animal>();
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                try
                {
                    string[] animalArgs = Console.ReadLine().Split();

                    var name = animalArgs[0];
                    var age = int.Parse(animalArgs[1]);
                    var gender = animalArgs[2];

                    if (input == "Cat")
                    {
                        var cat = new Cat(name, age, gender);
                        animals.Add(cat);

                    }
                    else if (input == "Dog")
                    {
                        var dog = new Dog(name, age, gender);

                        animals.Add(dog);
                    }
                    else if (input == "Frog")
                    {
                        var frog = new Frog(name, age ,gender);

                        animals.Add(frog);
                    }
                    else if (input == "Kitten")
                    {
                        var kitten = new Kitten(name, age, gender);

                        animals.Add(kitten);
                    }
                    else //Tomcat
                    {
                        var tomcat = new Tomcat(name, age, gender);

                        animals.Add(tomcat);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                animal.Greet();
            }


        }
    }
}