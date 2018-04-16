using System;
using System.Reflection;

namespace _01.Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var personArgs = Console.ReadLine().Split();
                var person = new Person();

                person.Name = personArgs[0];
                person.Age = int.Parse(personArgs[1]);
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember());

        }
    }
}