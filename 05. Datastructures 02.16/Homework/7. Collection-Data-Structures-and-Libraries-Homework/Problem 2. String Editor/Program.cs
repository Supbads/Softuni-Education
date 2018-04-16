namespace Problem_2.String_Editor
{
    using System;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main(string[] args)
        {
            BigList<char> stringEditor = new BigList<char>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                var inputTokens = input.Split();

                int index;
                int deleteCount;
                switch (inputTokens[0])
                {
                    case "APPEND":

                        foreach (string token in inputTokens)
                        {
                            if (token == "APPEND")
                            {
                                continue;
                            }

                            foreach (char c in token)
                            {
                                stringEditor.Add(c);
                            }
                        }

                        Console.WriteLine("OK");
                        break;
                    case "INSERT":
                        //INSERT 0 456  
                        index = int.Parse(inputTokens[1]);
                        if (index + inputTokens[2].Length > stringEditor.Count) // possible -1
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }
                        
                        foreach (char c in inputTokens[2])
                        {
                            stringEditor.Insert(index, c);
                            index++;
                        }

                        Console.WriteLine("OK");
                        break;
                    case "REPLACE":
                        //REPLACE 1 5 kiro
                        index = int.Parse(inputTokens[1]);
                        deleteCount = int.Parse(inputTokens[2]);
                        if (index + 2 > stringEditor.Count) //possible -1
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }
                        
                        stringEditor.RemoveRange(index, deleteCount); //possible +1/-1

                        foreach (char c in inputTokens[3])
                        {
                            stringEditor.Insert(index, c);
                            index++;
                        }

                        //Console.WriteLine("AFTER TE REPLACE :");
                        //foreach (char c in stringEditor)
                        //{
                        //    Console.Write(c);
                        //}
                        //Console.WriteLine();
                        Console.WriteLine("OK");
                        break;
                    case "DELETE":
                        index = int.Parse(inputTokens[1]);
                        if (index + inputTokens[2].Length > stringEditor.Count)
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }

                        deleteCount = int.Parse(inputTokens[2]);
                        stringEditor.RemoveRange(index, deleteCount);

                        Console.WriteLine("OK");
                        break;
                    case "PRINT":
                        foreach (char c in stringEditor)
                        {
                            Console.Write(c);
                        }

                        Console.WriteLine();
                        //Console.WriteLine("OK");
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
