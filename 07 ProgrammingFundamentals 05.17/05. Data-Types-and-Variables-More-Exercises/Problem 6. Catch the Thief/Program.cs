using System;

namespace Problem_6.Catch_the_Thief
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] dataType = new[] { false, false, false };

            string type = Console.ReadLine();
            long maxId;
            
            if (type == "sbyte")
            {
                dataType[0] = true;
                maxId = sbyte.MinValue;
            }
            else if (type == "int")
            {
                dataType[1] = true;
                maxId = int.MinValue;
            }
            else
            {
                dataType[2] = true;
                maxId = long.MinValue;
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
                    else if (numberToCheck < sbyte.MaxValue)
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
                    else if (numberToCheck < int.MaxValue)
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
                    else if (numberToCheck < long.MaxValue)
                    {
                        if (numberToCheck > maxId)
                        {
                            maxId = numberToCheck;
                        }
                    }
                    continue;
                }
            }


            Console.WriteLine(maxId);
        }
    }
}

//using System;

//class SentenceTheThief
//{
//    static void Main()
//    {
//        string numeralType = Console.ReadLine();
//        int n = int.Parse(Console.ReadLine());

//        long maxID = long.MinValue;

//        for (int i = 0; i < n; i++)
//        {
//            long inputID = long.Parse(Console.ReadLine());
//            if (numeralType == "sbyte")
//            {
//                if (inputID > sbyte.MaxValue)
//                {
//                    continue;
//                }
//                if (inputID == sbyte.MaxValue)
//                {
//                    maxID = inputID;
//                    break;
//                }
//                else if (inputID < sbyte.MaxValue)
//                {
//                    if (inputID > maxID)
//                    {
//                        maxID = inputID;
//                    }
//                }
//            }
//            else if (numeralType == "int")
//            {
//                if (inputID > int.MaxValue)
//                {
//                    continue;
//                }
//                if (inputID == int.MaxValue)
//                {
//                    maxID = inputID;
//                    break;
//                }
//                else if (inputID < int.MaxValue)
//                {
//                    if (inputID >= maxID)
//                    {
//                        maxID = inputID;
//                    }
//                }
//            }
//            else if (numeralType == "long")
//            {
//                if (inputID == long.MaxValue)
//                {
//                    maxID = inputID;
//                    break;
//                }
//                else if (inputID < sbyte.MaxValue)
//                {
//                    if (inputID >= maxID)
//                    {
//                        maxID = inputID;
//                    }
//                }
//            }
//        }

//        long sentence = 1;

//        if (maxID > sbyte.MaxValue)
//        {
//            sentence = (maxID / 127) + 1;
//        }
//        else if (maxID < sbyte.MinValue)
//        {
//            sentence = (maxID / -128) + 1;
//        }

//        if (sentence > 1)
//        {
//            Console.WriteLine($"Prisoner with id {maxID} is sentenced to {sentence} years");
//        }
//        else
//        {
//            Console.WriteLine($"Prisoner with id {maxID} is sentenced to {sentence} year");
//        }
//    }
//}