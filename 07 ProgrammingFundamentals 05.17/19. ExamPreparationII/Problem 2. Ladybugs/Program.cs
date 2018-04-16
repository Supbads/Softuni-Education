using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Ladybugs
{
    class Program
    {
        static void Main()
        {
            long fieldSize = long.Parse(Console.ReadLine());

            bool[] field = new bool[fieldSize];

            var bugIndexes = Console.ReadLine().Split().Select(long.Parse).Where(x => x >= 0 && x < fieldSize).ToList();

            foreach (var bugIndex in bugIndexes)
            {
                field[bugIndex] = true;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                var tokens = input.Split();
                long startingIndex = long.Parse(tokens[0]);

                if (startingIndex < 0 || startingIndex >= field.Length)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (field[startingIndex] == false)
                {
                    input = Console.ReadLine();
                    continue;
                }

                long moves = long.Parse(tokens[2]);

                if (tokens[1] == "right")
                {
                    field[startingIndex] = false;
                    bool flag = true;
                    long newIndex = startingIndex + moves;
                    if (newIndex >= field.Length)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    while (field[newIndex] == true)//there's already another ladybug
                    {
                        newIndex += moves;
                        if (newIndex >= field.Length)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        field[newIndex] = true;
                    }
                }
                else if (tokens[1] == "left")
                {
                    field[startingIndex] = false;
                    bool flag = true;
                    long newIndex = startingIndex - moves;
                    if (newIndex < 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    while (field[newIndex] == true)//there's already another ladybug
                    {
                        newIndex -= moves;

                        if (newIndex < 0)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        field[newIndex] = true;
                    }
                }

                input = Console.ReadLine();
            }


            foreach (var ladybug in field)
            {
                Console.Write(ladybug ? "1 " : "0 ");
            }
        }
    }
}
