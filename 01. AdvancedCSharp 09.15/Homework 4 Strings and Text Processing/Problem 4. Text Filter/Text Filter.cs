using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        //Linux, Windows
        //It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the functionality. Therefore we owe it to them by calling the OS GNU/Linux! Sincerely, a Windows client
        string[] banList = Console.ReadLine().Split(new string[] {","," "},StringSplitOptions.RemoveEmptyEntries);
        string text = Console.ReadLine();

        text = banList.Aggregate(text, (current, word) => current.Replace(word, new string('*', word.Length)));

        Console.WriteLine(text);
    }
}
