using System;

class SentenceTheThief
{
    static void Main(string[] args)
    {
        bool[] dataType = new[] {false, false, false};

        string type = Console.ReadLine();
        long maxId = long.MinValue;

        if (type == "sbyte")
        {
            dataType[0] = true;
        }
        else if (type == "int")
        {
            dataType[1] = true;
        }
        else
        {
            dataType[2] = true;
        }

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var numberToCheck = long.Parse(Console.ReadLine());

            if (dataType[0])
            {
                if (numberToCheck > sbyte.MaxValue)
                {
                    continue;
                }
                if (numberToCheck == sbyte.MaxValue)
                {
                    maxId = numberToCheck;
                    break;
                }
                if (numberToCheck < sbyte.MaxValue)
                {
                    if (numberToCheck > maxId)
                    {
                        maxId = numberToCheck;
                    }
                }
                
                continue;
            }

            if (dataType[1])
            {
                if (numberToCheck > int.MaxValue)
                {
                    continue;
                }
                if (numberToCheck == int.MaxValue)
                {
                    maxId = numberToCheck;
                    break;
                }
                if (numberToCheck < int.MaxValue)
                {
                    if (numberToCheck > maxId)
                    {
                        maxId = numberToCheck;
                    }
                }
                continue;
            }

            if (dataType[2])
            {
                if (numberToCheck > long.MaxValue)
                {
                    continue;
                }
                if (numberToCheck == long.MaxValue)
                {
                    maxId = numberToCheck;
                    break;
                }
                if (numberToCheck < long.MaxValue)
                {
                    if (numberToCheck > maxId)
                    {
                        maxId = numberToCheck;
                    }
                }
            }
        }

        double sentence = 1;

        if (maxId > sbyte.MaxValue)
        {
            sentence = Math.Ceiling((double)maxId / 127);
        }
        else if (maxId < sbyte.MinValue)
        {
            sentence = Math.Ceiling((double)maxId / -128);
        }

        if (sentence > 1)
        {
            Console.WriteLine($"Prisoner with id {maxId} is sentenced to {sentence} years");
        }
        else
        {
            Console.WriteLine($"Prisoner with id {maxId} is sentenced to {sentence} year");
        }
    }
}