using System;

class TouristInfomation
{
    static void Main(string[] args)
    {
        string unit = Console.ReadLine();
        decimal value = decimal.Parse(Console.ReadLine());
        
        decimal result = 0;
        string convertedUnit = "";

        if (unit == "miles")
        {
            decimal convertionNumber = 1.6m;
            result = convertionNumber * value;

            convertedUnit = "kilometers";
        }
        else if (unit == "inches")
        {
            decimal convertionNumber = 2.54m;
            result = convertionNumber * value;

            convertedUnit = "centimeters";
        }
        else if (unit == "feet")
        {
            decimal convertionNumber = 30m;
            result = convertionNumber * value;

            convertedUnit = "centimeters";
        }
        else if (unit == "yards")
        {
            decimal convertionNumber = 0.91m;
            result = convertionNumber * value;

            convertedUnit = "meters";
        }
        else if (unit == "gallons")
        {
            decimal convertionNumber = 3.8m;
            result = convertionNumber * value;

            convertedUnit = "liters";
        }

        Console.WriteLine("{0} {1} = {2:0.00} {3}", value, unit, result, convertedUnit);
    }
}
