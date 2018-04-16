using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortArrayUsingSelectionSort
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] splitInput = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //IEnumerable<string> myResults = someString.Split(';').Where<string>(s => !string.IsNullOrEmpty(s));

        int[] numbers = FillArray(splitInput);

        SelectionSort(numbers);

        foreach (var number in numbers)
        {
            Console.WriteLine(number + " ");
        }
    }

    private static int[] FillArray(string[] splitInput)
    {
        int[] numbers = new int[splitInput.GetLength(0)];

        for (int i = 0; i < splitInput.Length; i++)
        {
            numbers[i] = int.Parse(splitInput[i]);

        }

        return numbers;
    }

    private static void SelectionSort(int[] numbers)
    {
        int key, temp;
        for (int i = 0; i < numbers.Length; i++)
        {

            key = i;
            temp = 0;

            for(int j = i + 1 ; j < numbers.Length; j++)
            {
                if(numbers[j]<numbers[key])
                {
                    key = j;
                }
            }
                temp = numbers[key];
                numbers[key] = numbers[i];
                numbers[i] = temp;
        }
    }
}
