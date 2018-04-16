using System;

class CheckForaPlayCard
{
    static void Main()
    {
        string a = Console.ReadLine();
        string checkTwo = "2";
        string checkThree = "3";
        string checkFour = "4";
        string checkFive = "5";
        string checkSix = "6";
        string checkSeven = "7";
        string checkEight = "8";
        string checkNine = "9";
        string checkTen = "10";
        string checkJack = "J";
        string checkQueen = "Q";
        string checkKing = "K";
        string checkAce = "A";
        bool check = (a == checkTwo) || (a == checkThree)||(a==checkFour)||(a==checkFive)||(a==checkSix)||(a==checkSeven)||(a==checkEight)||(a==checkNine)||(a==checkTen)||(a==checkJack)||(a==checkQueen)||(a==checkKing)||(a==checkAce);
        if (check)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
