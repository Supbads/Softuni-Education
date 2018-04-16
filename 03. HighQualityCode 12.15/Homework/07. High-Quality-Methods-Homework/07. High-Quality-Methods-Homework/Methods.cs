namespace Methods
{
    using System;
    
    /// <summary>
    /// Holds utility methods
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Method that calculates the area of a triangle
        /// by given three sides using heron's formula
        /// </summary>
        /// <param name="a">Side a of the triangle</param>
        /// <param name="b">Side b of the triangle</param>
        /// <param name="c">Side c of the triangle</param>
        /// <returns>Returns the area of the triangle as a double</returns>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides of a triangle cannot be a negative value");
            }
            if (!IsTriangleValid(a, b, c))
            {
                throw new ArgumentException("The given sides don't form a valid triangle");
                //not sure if those should be invalid operation exceptions, but the given arguments are wrong so..
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        /// <summary>
        /// Check's whether a triangle is valid by given three sides
        /// </summary>
        /// <param name="a">Side a of the triangle</param>
        /// <param name="b">Side b of the triangle</param>
        /// <param name="c">Side c of the triangle</param>
        /// <returns>Returns true if the triangle is valid and false if it's not</returns>
        private static bool IsTriangleValid(double a, double b, double c)
        {
            bool isFirstSideValid = a < b + c;
            bool isSecondSideValid = b < a + c;
            bool isThirdSideValid = c < a + b;

            bool isTriangleValid = isFirstSideValid && isSecondSideValid && isThirdSideValid;

            return isTriangleValid;
        }

        /// <summary>
        /// Converts an integer number to it's representation as string
        /// </summary>
        /// <param name="number">The number to be converted</param>
        /// <returns>Returns the converted digit as string</returns>
        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentException("The number cannot be represented as a digit");
        }

        /// <summary>
        /// Finds the largest element in an array of integers
        /// </summary>
        /// <param name="elements">The array to search for the largest element</param>
        /// <returns>Returns the largest element in the array</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("The collection is empty");
            }

            int collectionMaxValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    collectionMaxValue = elements[i];
                }
            }

            return collectionMaxValue;
        }

        /// <summary>
        /// Prints a number by a given format
        /// </summary>
        /// <param name="number">The number to be printed</param>
        /// <param name="format">Te format for the number to be printed in</param>
        public static void PrintAsNumber(object number, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentException("The format cannot be null or empty");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("The following format does not exist");
            }
        }
        
        /// <summary>
        /// Calculates the distance between two points using the Pythagorean theorem
        /// and checks if the two points are horizontal or vertical on the coordinate system
        /// </summary>
        /// <param name="x1">The X coordinate of the first point</param>
        /// <param name="y1">The Y coordinate of the first point</param>
        /// <param name="x2">The X coordinate of the second point</param>
        /// <param name="y2">The Y coordinate of the second point</param>
        /// <param name="isHorizontal">ref bool variable which will hold whether the points are horizontal or not</param>
        /// <param name="isVertical">ref bool variable which will hold whether the points are vertical or not</param>
        /// <returns>Returns the distance between the two points in 2D plane and the gives value to the out variables</returns>
        public static double CalcDistance(double x1, double y1, double x2, double y2, 
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (y1 == y2);
            isVertical = (x1 == x2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }
    }
}
