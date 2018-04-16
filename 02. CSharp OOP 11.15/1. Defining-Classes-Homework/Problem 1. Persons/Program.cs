using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your person's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your person's age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your person's email(Optional, enter \"No\" to ignore) ");
            string email = Console.ReadLine();
            try
            {
                if (email != "No")
                {
                    Person person = new Person(name, (uint)age, email);
                    Console.WriteLine(person.ToString());   
                }
                else 
                {
                    Person person = new Person(name, (uint)age);
                    Console.WriteLine(person.ToString());   
                }
                
            }            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Person gosho = new Person("pesho",20,"goshoPesho@is.life");
            //Console.WriteLine(gosho.ToString());          

        }
    }
}
