using System;

namespace Problem_3.String_Disperser
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDisperser stringDisperser = new StringDisperser("gosho","pesho","tanio");
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch+" ");
            }
            Console.WriteLine();

            var sD2 = (StringDisperser)stringDisperser.Clone();
            var sD3 = (StringDisperser)sD2.Clone();
            Console.WriteLine("disperser2 is equal to disperser3 ? " + sD2.CompareTo(sD3));
            Console.WriteLine("disperser2 hash code: " + sD2.GetHashCode());
            Console.WriteLine("disperser3 hash code: " + sD3.GetHashCode());

            Console.WriteLine("disperser2 hash code is equal to disperser 3 hash code? " + (sD2.GetHashCode().CompareTo(sD3.GetHashCode()) == 0 ? "true" : "false"));
        }
    }
}
