using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Play_Catch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();


            string command = Console.ReadLine();

            int exceptionsCaught = 0;

            while (exceptionsCaught < 3)//could work with while(true)
            {
                try
                {
                    var tokens = command.Split();

                    if (tokens[0] == "Replace")
                    {
                        var index = int.Parse(tokens[1]);
                        var element = int.Parse(tokens[2]);

                        arr[index] = element;
                    }
                    else if (tokens[0] == "Show")
                    {
                        var index = int.Parse(tokens[1]);
                        Console.WriteLine(arr[index]);
                    }
                    else if (tokens[0] == "Print")
                    {
                        var low = int.Parse(tokens[1]);
                        var high = int.Parse(tokens[2]);

                        //var attempt = arr.Skip(low).Take(high - low + 1);
                        var attempt = new List<int>();

                        for (int i = low; i <= high; i++)
                        {
                            attempt.Add(arr[i]);   
                        }

                        Console.WriteLine(string.Join(", ", attempt));
                        
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCaught++;
                    if (exceptionsCaught >= 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCaught++;
                    if (exceptionsCaught >= 3)
                    {
                        break;
                    }
                }

                command = Console.ReadLine();
            }


            Console.WriteLine(string.Join(", ", arr));

        }
    }
}
