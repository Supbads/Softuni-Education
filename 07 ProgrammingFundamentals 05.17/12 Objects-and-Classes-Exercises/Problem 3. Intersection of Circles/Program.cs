using System;

namespace Problem_3.Intersection_of_Circles
{
    public class Circle
    {
        public Circle(int x, int y, int radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public bool Interesects(Circle secondCircle)
        {
            bool isInteresecting = false;

            var radiusSum = this.Radius + secondCircle.Radius;

            var distance = Math.Sqrt(Math.Pow(secondCircle.X - this.X, 2)  + Math.Pow(secondCircle.Y - this.Y, 2));

            if (radiusSum >= distance)
            {
                isInteresecting = true;
            }

            return isInteresecting;
        }
    }

    class Program
    {
        static void Main()
        {
            var firstCircleTokens = Console.ReadLine().Split();
            var secondCircleTokens = Console.ReadLine().Split();

            var ax = int.Parse(firstCircleTokens[0]);
            var ay = int.Parse(firstCircleTokens[1]);
            var aRadius = int.Parse(firstCircleTokens[2]);

            Circle firstCircle = new Circle(ax, ay, aRadius);

            var bx = int.Parse(secondCircleTokens[0]);
            var by = int.Parse(secondCircleTokens[1]);
            var bRadius = int.Parse(secondCircleTokens[2]);

            Circle secondCircle = new Circle(bx, by, bRadius);

            var isInteresecting = firstCircle.Interesects(secondCircle);

            Console.WriteLine(isInteresecting ? "Yes" : "No");
        }
    }
}
