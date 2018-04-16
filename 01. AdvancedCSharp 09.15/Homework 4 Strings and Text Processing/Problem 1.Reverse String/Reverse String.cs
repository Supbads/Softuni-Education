using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter strings:");
            string input = Console.ReadLine();
            if(input=="END")
            {
                break;
            }
            Console.WriteLine(string.Join("", input.Reverse()));
            Console.WriteLine("Type \"END\" to stop the program.");
        }
    }
}
