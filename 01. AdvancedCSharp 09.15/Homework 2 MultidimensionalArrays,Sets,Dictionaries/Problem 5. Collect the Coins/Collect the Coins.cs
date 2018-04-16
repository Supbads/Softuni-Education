using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CollectTheCoins
{
    static int _currRow = 0;
    static int _currCol = 0;
    static int _coins = 0;
    static int _wallHits = 0;

    static void Main()
    {
        string[] field = new string[4];
        GetInputs(field);
        string moves = Console.ReadLine();
        DoMoves(moves, field);
        PrintResult();
    }

    static void DoMoves(string moves, string[] field)
    {
        CollectCoin(field); // if there's a coin on {0, 0}
        foreach (char move in moves)
        {
            switch (move)
            {
                case '>':
                    PerformMove(field, _currRow, _currCol + 1);
                    break;
                case '<':
                    PerformMove(field, _currRow, _currCol - 1);
                    break;
                case '^':
                    PerformMove(field, _currRow - 1, _currCol);
                    break;
                case 'V':
                    PerformMove(field, _currRow + 1, _currCol);
                    break;
            }
        }
    }

    static void PerformMove(string[] field, int row, int col)
    {
        if (ValidMove(field, row, col))
        {
            _currCol = col;
            _currRow = row;
            CollectCoin(field);
        }
        else
        {
            _wallHits++;
        }
    }

    static void PrintResult()
    {
        Console.WriteLine("Coins collected: {0}", _coins);
        Console.WriteLine("Walls hit: {0}", _wallHits);
    }

    static void CollectCoin(string[] field)
    {
        if (field[_currRow][_currCol] == '$')
        {
            _coins++;
        }
    }

    static bool ValidMove(string[] field, int row, int col)
    {
        if (row >= 0 && row < field.Length)
        {
            if (col >= 0 && col < field[row].Length)
            {
                return true;
            }
        }
        return false;
    }

    static void GetInputs(string[] field)
    {
        for (int i = 0; i < field.Length; i++)
        {
            field[i] = Console.ReadLine();
        }
    }
}
