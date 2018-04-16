using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Problem_1.Shapes.Interfaces;

namespace Problem_1.Shapes
{
    class Circle : IShape
    {
        private const double Pi = Math.PI;
        private double radius;
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("radius","Circle radius cannot be negative");
                }
                if (value == 0d)
                {
                    throw new ArgumentOutOfRangeException("radius","Circle radius cannot be zero");
                }
                radius = value;
            }
        }

        public double CalculateArea()
        {
            return Pi*radius*radius;
        }

        public double CalculatePerimeter()
        {
            return 2d*Pi*radius;
        }
    }
}
