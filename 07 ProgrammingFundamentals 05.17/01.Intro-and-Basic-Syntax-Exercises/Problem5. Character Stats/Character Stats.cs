using System;

namespace Problem5.Character_Stats
{
    public enum ResourceType
    {
        Health,
        Energy
    }

    class Program
    {
        static string characterName;

        static int currentHealth;

        static int maximumHealth;

        static int currentEnergy;

        static int maximumEnergy;

        static char defaultDisplayCharacter = '|';

        static char defaultEmptyCharacter = '.';


        static void Main(string[] args)
        {
            ReadInput();

            DisplayName();

            DisplayBarFormat(maximumHealth, currentHealth, ResourceType.Health);

            DisplayBarFormat(maximumEnergy, currentEnergy, ResourceType.Energy);
        }

        private static void DisplayBarFormat(int numberOfAllSymbols, int numberOfLines, ResourceType resourceType)
        {
           
            Console.Write("{0}: {1}", resourceType.ToString(), defaultDisplayCharacter);

            int numberOfTimesToFill = numberOfAllSymbols - numberOfLines;

            Console.Write(new string(defaultDisplayCharacter, numberOfLines));

            Console.Write(new string(defaultEmptyCharacter, numberOfTimesToFill));

            Console.WriteLine(defaultDisplayCharacter);

        }

        private static void DisplayName()
        {
            string nameToDisplay = "Name: " + characterName;

            Console.WriteLine(nameToDisplay);
        }

        private static void ReadInput()
        {
            characterName = Console.ReadLine();
            currentHealth = int.Parse(Console.ReadLine());
            maximumHealth = int.Parse(Console.ReadLine());
            currentEnergy = int.Parse(Console.ReadLine());
            maximumEnergy = int.Parse(Console.ReadLine());
        }
    }
}
