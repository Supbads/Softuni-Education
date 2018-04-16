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
        if(input.Length>=20)
        {
            //char[] a = new char[20];
            //for (int i = 0; i < 20; i++)
            //{
            //    a[i] = input[i];
            //}
            //Console.WriteLine(a);
            Console.WriteLine(input.Substring(0,20));
        }
        else
        {
            Console.WriteLine(input+new string('*',20-input.Length));
        }
    }
}
