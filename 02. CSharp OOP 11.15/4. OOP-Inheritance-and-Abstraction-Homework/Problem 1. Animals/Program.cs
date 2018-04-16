using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[9];
            animals[0] = new Dog("sharo", 5, "Male");
            animals[1] = new Cat("pisa", 4, "Female");
            animals[2] = new Frog("jabochka", 17 , "Female");
            animals[3] = new Kitten("Lusi", 3);
            animals[4] = new Frog("jabok", 20, "Male");
            animals[5] = new Tomcat("TopCat", 12);
            animals[6] = new Dog("kucheVJenskiRod", 13, "Female");
            animals[7] = new Tomcat("ISuck", 8);
            animals[8] = new Kitten("AtNames", 7);

            //double catsAverageAge = animals
            //        .Where(animal => animal is Cat)
            //        .Average(cat => cat.Age);
            //double dogsAverageAge = animals
            //        .Where(animal => animal is Dog)
            //        .Average(dog => dog.Age);
            //double frogsAverageAge = animals
            //    .Where(animal => animal is Frog)
            //    .Average(frog => frog.Age);

            //Console.WriteLine("Frogs average age is: {0:F2}", frogsAverageAge);
            //Console.WriteLine("Dogs average age is: {0:F2}", dogsAverageAge);
            //Console.WriteLine("Cats average age is: {0:F2}", catsAverageAge);
            foreach (var kind in animals.GroupBy(x => x.GetType()))
            {
                double averageAge = kind.Select(x => x.Age).Average();
                Console.WriteLine("Animal : {0}, AverageAge: {1}", kind.Key, averageAge);
            }

            foreach (Animal animal in animals)
            {
                animal.ProduceSound();
            }
        }
    }
}
