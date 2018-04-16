using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        int key = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        char[] encryptedText = new char[n];

        for (int i = 0; i < n; i++)
        {
            encryptedText[i] = Console.ReadLine().FirstOrDefault();
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write((char)(encryptedText[i] + key));
        }

    }
}