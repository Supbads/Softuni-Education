using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11.Dragon_Army
{
    class DragonComparer : IComparer<Dragon>
    {
        public int Compare(Dragon x, Dragon y)
        {
            return string.Compare(x.Name, y.Name);
        }

        public static IComparer<Dragon> GetComparer()
        {
            return new DragonComparer();
        }
    }


    public class Dragon 
    {
        public Dragon(string name, string damage = "45", string health = "250", string armour = "10")
        {
            this.Name = name;

            this.TryParsingInput(damage, health, armour);

        }

        private void TryParsingInput(string damage, string health, string armour)
        {
            this.Damage = 45;
            if (damage != "null")
            {
                this.Damage = int.Parse(damage);
            }

            this.Health = 250;
            if (health != "null")
            {
                this.Health = int.Parse(health);
            }

            this.Armour = 10;
            if (armour != "null")
            {
                this.Armour = int.Parse(armour);
            }
        }

        public string Name { get; private set; }

        public int Damage { get; set; }

        public int Health { get; set; }

        public int Armour { get; set; }

        public override string ToString()
        {
            return $"-{this.Name} -> damage: {this.Damage}, health: {this.Health}, armor: {this.Armour}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Dragon && obj != null)
            {
                Dragon other = (Dragon)obj;
                return (other.Name == this.Name);
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<Dragon>> typesAndDragons = new Dictionary<string, SortedSet<Dragon>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split();

                var type = tokens[0];
                var name = tokens[1];
                var damage = tokens[2];
                var health = tokens[3];
                var armour = tokens[4];

                Dragon currentDragon = new Dragon(name, damage, health, armour);

                if (!typesAndDragons.ContainsKey(type))
                {
                    typesAndDragons.Add(type, new SortedSet<Dragon>(DragonComparer.GetComparer()));
                }

                //typesAndDragons[type].Add(currentDragon);

                if (typesAndDragons[type].Any(d => d.Name == name))
                {
                    typesAndDragons[type].RemoveWhere(d => d.Name == name);
                }
                
                typesAndDragons[type].Add(currentDragon);
                

                //If the same dragon is added a second time, the new stats should overwrite the previous ones
                //Two dragons are considered equal if they match by both name and type.

            }


            //to print

            foreach (var typeAndDragonsPair in typesAndDragons)
            {
                var currentType = typeAndDragonsPair.Key;
                var listOfDragons = typeAndDragonsPair.Value;

                var damageAverage = listOfDragons.Average(x => x.Damage);
                var healthAverage = listOfDragons.Average(x => x.Health);
                var armourAverage = listOfDragons.Average(x => x.Armour);

                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", currentType, damageAverage, healthAverage, armourAverage);
                Console.WriteLine(string.Join("\n", listOfDragons));
            }

        }
    }
}