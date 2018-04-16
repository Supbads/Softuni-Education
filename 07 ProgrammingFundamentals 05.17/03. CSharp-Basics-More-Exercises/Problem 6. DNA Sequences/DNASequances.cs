using System;
using System.Collections.Generic;

namespace Problem_6.DNA_Sequences
{
    
    class DNASequances
    {
        static char[] nucleotides = new[] {' ', 'A', 'C', 'G', 'T'};

        static int maxNucleotidesPerSum = 3;

        //static List<string> matchingSums = new List<string>();

        private static int targetSum;

        static void Main(string[] args)
        {
            targetSum = int.Parse(Console.ReadLine());

            string sequance = "";

            int currentIndex = 1;
            int currentSum = 0;

            for (int i = 1; i < nucleotides.Length; i++)
            {
                for (int j = 1; j < nucleotides.Length; j++)
                {
                    for (int h = 1; h < nucleotides.Length; h++)
                    {
                        if (i + j + h >= targetSum)
                        {
                            Console.Write("O{0}{1}{2}O ",nucleotides[i], nucleotides[j], nucleotides[h]);
                        }
                        else
                        {
                            Console.Write("X{0}{1}{2}X ", nucleotides[i], nucleotides[j], nucleotides[h]);
                        }
                    }
                    Console.WriteLine();
                }
            }


            //GenerateSequance(sequance, currentIndex, currentSum);
        }

        //private static void GenerateSequance(string sequance, int i, int currentSum)
        //{
        //    if (i > maxNucleotidesPerSum + 1)
        //    {
        //        return;
        //    }
        //    if(currentSum >= )
        
        //}
    }
}