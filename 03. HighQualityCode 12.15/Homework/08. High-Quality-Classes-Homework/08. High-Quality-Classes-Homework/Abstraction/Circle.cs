namespace Abstraction
{
    using System;

    using Abstraction.Interfaces;

    class Circle : Figure, ICircle
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        
        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius", "figure's radius must be positive");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
