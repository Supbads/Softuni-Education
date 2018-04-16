using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool[] primes = new bool[n + 1];

            for (int i = 2; i < primes.Length; i++)
            {
                primes[i] = true;
            }


            //sieve
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    int sieve = i + i;
                    while (sieve < primes.Length)
                    {
                        primes[sieve] = false;
                        sieve += i;
                    }
                }
            }

            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    Console.Write("{0} ", i);
                }
            }


        }
    }
}
