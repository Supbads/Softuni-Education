using System;

class PlayWithIntDoubleString
{
    static void Main()
    {
        string one = "1";
        string two = "2";
        string three = "3";

        Console.WriteLine("Please choose a type: \n1 --> int \n2 --> double \n3 --> string");

        string input = Console.ReadLine();
        if (input == one)
        {
            Console.WriteLine("Please enter an int:");
            int secondinput = int.Parse(Console.ReadLine());
            Console.WriteLine(++secondinput);
        }
        else if (input == two)
        {
            Console.WriteLine("Please enter a double");
            double secondinput = double.Parse(Console.ReadLine());
            Console.WriteLine(++secondinput);
        }
        else if (input == three)
        {
            Console.WriteLine("Please enter a string:");
            string secondString = Console.ReadLine();
            Console.WriteLine(secondString+"*");

        }


    }
}
