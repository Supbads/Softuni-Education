using System;

class InstructionSet_broken
{
    static void Main()
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] tokens = input.Split(' ');

            long result = 0;
            switch (tokens[0])
            {
                case "INC":
                {
                    long operandOne = long.Parse(tokens[1]);
                    result = ++operandOne;
                    break;
                }
                case "DEC":
                {
                    long operandOne = long.Parse(tokens[1]);
                    result = --operandOne;
                    break;
                }
                case "ADD":
                {
                    long operandOne = long.Parse(tokens[1]);
                    long operandTwo = long.Parse(tokens[2]);
                    result = (long)operandOne + operandTwo;
                    break;
                }
                case "MLA":
                {
                    long operandOne = long.Parse(tokens[1]);
                    long operandTwo = long.Parse(tokens[2]);
                    result = (operandOne * operandTwo);
                    break;
                }
            }
            input = Console.ReadLine();

            Console.WriteLine(result);
        }
    }
}