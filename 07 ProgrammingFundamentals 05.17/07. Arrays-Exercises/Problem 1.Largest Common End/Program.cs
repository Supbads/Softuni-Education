using System;

class Program
{
    static void Main()
    {
        string[] firstArray = Console.ReadLine().Split();
        string[] secondArray = Console.ReadLine().Split();

        ushort commonLeftEnd = 0;
        ushort commonRightEnd = 0;

        ushort smallerLength = (ushort)Math.Min(firstArray.Length, secondArray.Length);
            
        for (ushort i = 0; i < smallerLength; i++)
        {
            if (firstArray[i] == secondArray[i])
            {//check left end
                commonLeftEnd++;
            }

            if (firstArray[firstArray.Length - 1 - i] == secondArray[secondArray.Length - 1 - i])
            {//check right end
                commonRightEnd++;
            }
        }

        Console.WriteLine(Math.Max(commonLeftEnd,commonRightEnd));

    }
}
