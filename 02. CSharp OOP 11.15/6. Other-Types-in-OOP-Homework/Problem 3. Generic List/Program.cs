using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Generic_List
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> ayy = new GenericList<int>();
            ayy.Add(145);
            ayy.Add(7);
            Console.WriteLine(ayy);
            ayy.Remove(7);
            Console.WriteLine(ayy);
            int c = 15;
            for (int i = 0; i < ayy.Size; i++)
            {
                ayy[i] = c;
            }
            ayy.RemoveAt(5);
            Console.WriteLine(ayy);
            ayy.Insert(3,4);
            ayy.RemoveAll(15);
            Console.WriteLine(ayy);
            ayy.Clear();
            Console.WriteLine(ayy);

            var customAttributes = typeof(GenericList<>).GetCustomAttributes(typeof(VersionAttribute), true);
            Console.WriteLine("This GenericList<T> class's version is {0}", customAttributes[0]);
        }
    }
}
