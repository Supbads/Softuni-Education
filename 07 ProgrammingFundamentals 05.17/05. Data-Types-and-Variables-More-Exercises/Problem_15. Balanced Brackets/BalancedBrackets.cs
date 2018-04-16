using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int numberOfOpeningBrackets = 0;
        int numberOfClosingBrackets = 0;

        bool previousWasAnOpeningBracket = false; //bind the first bracket to be an opening one and keeps everything neat
        
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (input.StartsWith("("))
            {
                numberOfOpeningBrackets++;
                if (previousWasAnOpeningBracket)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }

                previousWasAnOpeningBracket = true;
            }
            else if (input.StartsWith(")"))
            {
                if (previousWasAnOpeningBracket == false)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
                numberOfClosingBrackets++;
                previousWasAnOpeningBracket = false;
            }

            
        }

        Console.WriteLine(numberOfOpeningBrackets == numberOfClosingBrackets ? "BALANCED" : "UNBALANCED");

    }
}