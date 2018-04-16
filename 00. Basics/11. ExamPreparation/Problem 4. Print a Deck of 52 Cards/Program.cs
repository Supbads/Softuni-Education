using System;

class Program
{
    static void Main()
    {
        string[] facesCards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] colorsCards = { "♣", "♦", "♥", "♦" };

        Console.WriteLine("Standart deck of 52 play cards contain:");
        Console.WriteLine();
        foreach (var face in facesCards)
        {
            foreach (var color in colorsCards)
            {
                Console.Write("{0,3}{1} ", face, color);
            }

        }
    }
}
