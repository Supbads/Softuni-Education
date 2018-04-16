using System;
using System.Globalization;
using System.Linq;

namespace Problem_6.Byte_Flip
{
    class Program
    {
        static void Main()
        {
            string[] arr = Console.ReadLine().Split();

            arr = arr.Where(x => x.Length == 2).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new string(arr[i].Reverse().ToArray());
            }

            foreach (var element in arr.Reverse())
            {
                var dsa = (char)Int16.Parse(element, NumberStyles.AllowHexSpecifier);

                Console.Write(dsa);
            }
        }
    }
}
