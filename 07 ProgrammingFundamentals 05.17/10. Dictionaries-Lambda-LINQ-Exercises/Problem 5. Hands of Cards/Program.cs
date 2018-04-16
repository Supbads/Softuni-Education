using System;
using System.Collections.Generic;

namespace Problem_5.Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> peopleAndCards = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();

            while (input != "JOKER")
            {
                var tokens = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var cards = tokens[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0].Trim();


                if (!peopleAndCards.ContainsKey(name))
                {
                    peopleAndCards.Add(name, new HashSet<string>());
                }

                for (int i = 0; i < cards.Length; i++)
                {
                    peopleAndCards[name].Add(cards[i].Trim());
                }

                input = Console.ReadLine();
            }

            foreach (var nameAndCardsPair in peopleAndCards)
            {
                string currentName = nameAndCardsPair.Key;
                long sum = 0;

                foreach (var powerAndSuite in nameAndCardsPair.Value)
                {
                    if (powerAndSuite.Length > 2) //10
                    {
                        long suiteValue = GetSuite(powerAndSuite.Substring(2));
                        long faceValue = GetFace(powerAndSuite.Substring(0, 2));

                        sum += suiteValue * faceValue;
                    }
                    else
                    {
                        long suiteValue = GetSuite(powerAndSuite.Substring(1));
                        long faceValue = GetFace(powerAndSuite.Substring(0, 1));

                        sum += suiteValue * faceValue;
                    }
                }


                Console.WriteLine("{0}: {1}", currentName, sum);
            }
        }

        private static int GetFace(string face)
        {
            switch (face)
            {
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return int.Parse(face);
            }
        }

        private static int GetSuite(string suite)
        {
            switch (suite)
            {
                case "S":
                    return 4;
                case "H":
                    return 3;
                case "D":
                    return 2;
                case "C":
                    return 1;
                default:
                    return 0;
            }
        }
    }
}

//using System;
//using System.Collections.Generic;

//namespace Problem_5.Hands_of_Cards
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string[] powers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
//            string[] types =  { "0", "C", "D", "H", "S" };

//            Dictionary<string, HashSet<string>> peopleAndCards = new Dictionary<string, HashSet<string>>();

//            string input = Console.ReadLine();

//            while (input != "JOKER")
//            {
//                var tokens = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
//                var cards = tokens[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
//                var name = tokens[0].Trim();

//                if (!peopleAndCards.ContainsKey(name))
//                {
//                    peopleAndCards.Add(name, new HashSet<string>());
//                }

//                for (int i = 0; i < cards.Length; i++)
//                {
//                    peopleAndCards[name].Add(cards[i]);
//                }

//                input = Console.ReadLine();
//            }

//            foreach (var nameAndCardsPair in peopleAndCards)
//            {
//                string currentName = nameAndCardsPair.Key;
//                int sum = 0;

//                foreach (var powerAndType in nameAndCardsPair.Value)
//                {
//                    if (powerAndType.Length == 3) //10
//                    {
//                        int type = Array.IndexOf(types, powerAndType.Substring(2));
//                        sum += type * 10;
//                    }
//                    else
//                    {
//                        int power = Array.IndexOf(powers, powerAndType.Substring(0,1));//can try without tostring
//                        int type = Array.IndexOf(types, powerAndType.Substring(1));

//                        sum += power * type;
//                    }
//                }

//                Console.WriteLine("{0}: {1}", currentName, sum);

//            }
//        }
//    }
//}