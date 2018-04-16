using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string unicode = "";
        foreach (var character in input)
        {
            unicode += "\\u" + ((int)character).ToString("X4");
        }
        Console.WriteLine(unicode);
    }
}
