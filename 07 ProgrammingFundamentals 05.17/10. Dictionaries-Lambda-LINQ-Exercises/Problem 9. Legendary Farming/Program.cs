using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        SortedDictionary<string, int> keyMaterials = new SortedDictionary<string, int>();
        SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();
            
        // 0      , 1          , 2
        string[] keyMaterialsArr = new[] {"shards", "fragments", "motes"};
        string[] legendaries =  { "Shadowmourne", "Valanyr", "Dragonwrath" };

        SeedKeyMaterials(keyMaterials, keyMaterialsArr);

        StartFarming(keyMaterialsArr, keyMaterials, junkMaterials);

        int indexOfMaterialFound = -1;
        foreach (var materialQuantityPair in keyMaterials)
        {
            if (materialQuantityPair.Value >= 250)
            {
                indexOfMaterialFound = Array.IndexOf(keyMaterialsArr, materialQuantityPair.Key);
            }
        }

        keyMaterials[keyMaterialsArr[indexOfMaterialFound]] -= 250;

        Console.WriteLine("{0} obtained!", legendaries[indexOfMaterialFound]);

        foreach (var materialQuantityPair in keyMaterials.OrderByDescending(x => x.Value))
        {
            Console.WriteLine("{0}: {1}", materialQuantityPair.Key, materialQuantityPair.Value);
        }

        foreach (var junkMaterialQuantityPair in junkMaterials)
        {
            Console.WriteLine("{0}: {1}", junkMaterialQuantityPair.Key, junkMaterialQuantityPair.Value);
        }


        /*            
        Shadowmourne – requires 250 Shards;
        Valanyr – requires 250 Fragments;
        Dragonwrath – requires 250 Motes;
        */




    }

    private static void SeedKeyMaterials(SortedDictionary<string, int> keyMaterials, string[] keyMaterialsArr)
    {
        keyMaterials.Add(keyMaterialsArr[0], 0);
        keyMaterials.Add(keyMaterialsArr[1], 0);
        keyMaterials.Add(keyMaterialsArr[2], 0);
    }

    private static void StartFarming(string[] keyMaterialsArr, SortedDictionary<string, int> keyMaterials,
        SortedDictionary<string, int> junkMaterials)
    {
        while (true)
        {
            string input = Console.ReadLine();

            var tokens = input.Split();

            for (int i = 1; i < tokens.Length; i += 2)
            {
                int quantity = int.Parse(tokens[i - 1]);
                string material = tokens[i].ToLower();

                if (keyMaterialsArr.Contains(material))
                {
                    keyMaterials[material] += quantity;
                }
                else
                {
                    if (!junkMaterials.ContainsKey(material))
                    {
                        junkMaterials.Add(material, 0);
                    }

                    junkMaterials[material] += quantity;
                }

                if (keyMaterials.Values.Any(x => x >= 250))
                {
                    return;
                }
            }
        }
    }
}