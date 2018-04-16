using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // tests:
        // ababa caba  ;  
        // aba         ;  

        // Welcome to the Software University (SoftUni)! Welcome to programming. Programming is wellness for developers, said Maxwell.
        // wel

        string input = Console.ReadLine();
        string key = Console.ReadLine();
        int counter = 0;
        int subcounter = 0;
        for(int i = 0 ; i < input.Length - (key.Length-1) ; i++) 
        {
            subcounter = 0;
            for (int j = 0; j < key.Length; j++)
            {
                if((char.ToUpper(input[i+j]))==char.ToUpper(key[j]))
                {
                    subcounter++;
                }
                else
                {
                    continue;
                }
            }
            if(subcounter==key.Length)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }// could be shorted down with substing option but oh well..
}
