using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Morse_Code_Upgraded
{
    class Program
    {
        static void Main()
        {
            var args = Console.ReadLine().Split('|');
            
            long sum = 0;
            int currentLength = 1;

            string message = string.Empty;

            for (int i = 0; i < args.Length; i++)
            {
                string currentString = args[i];

                if (currentString[0] == '1')
                {
                    sum += 5;
                }
                else
                {
                    sum += 3;
                }

                for (int j = 1; j < currentString.Length; j++)
                {
                    if (currentString[j] == '1')
                    {
                        sum += 5;
                    }
                    else
                    {
                        sum += 3;
                    }

                    if (currentString[j] == currentString[j - 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (currentLength != 1)
                        {
                            sum += currentLength;
                        }

                        currentLength = 1;
                    }
                }


                if (currentLength != 1)
                {
                    sum += currentLength;
                }

                currentLength = 1;

                message += (char) sum;
                sum = 0;
            }

            Console.WriteLine(message);

        }
    }
}
