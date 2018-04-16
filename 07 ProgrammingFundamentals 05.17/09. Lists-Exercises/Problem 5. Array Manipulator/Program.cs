using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "print")
            {
                var tokens = command.Split();

                if (tokens[0] == "remove")
                {
                    int index = int.Parse(tokens[1]);
                    list.RemoveAt(index);
                }
                else if (tokens[0] == "add")
                {
                    int element = int.Parse(tokens[2]);
                    int insertionIndex = int.Parse(tokens[1]);

                    list.Insert(insertionIndex, element);
                }
                else if (tokens[0] == "addMany")
                {
                    int insertionIndex = int.Parse(tokens[1]);
                    for (int i = tokens.Length - 1; i > 1; i--)
                    {
                        int insertionNum = int.Parse(tokens[i]);

                        list.Insert(insertionIndex, insertionNum);
                    }

                }
                else if (tokens[0] == "shift")
                {
                    int offset = int.Parse(tokens[1]);
                    int length = list.Count;

                    List<int> tempList = new List<int>(list);

                    for (int i = 0; i < length; i++)
                    {
                        int asd = (i + offset) % length;

                        tempList[i] = list[(i + offset) % length];
                    }


                    list = tempList;

                }
                else if (tokens[0] == "contains")
                {
                    int searchNumber = int.Parse(tokens[1]);
                    Console.WriteLine(list.IndexOf(searchNumber));
                }
                else if (tokens[0] == "sumPairs")
                {
                    List<int> summedElements = new List<int>();

                    for (int i = 0; i < list.Count; i+=2)
                    {
                        int sum = 0;
                        if (i + 1 < list.Count)
                        {
                            sum += list[i] + list[i + 1];
                        }
                        else
                        {
                            sum += list[i];
                        }

                        summedElements.Add(sum);
                    }

                    list = summedElements;
                }
                
                command = Console.ReadLine();
            }


            Console.WriteLine("["+string.Join(", ", list) + "]");
            
        }
    }
}
