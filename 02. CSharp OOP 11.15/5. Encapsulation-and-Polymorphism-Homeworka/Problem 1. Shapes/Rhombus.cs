using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Shapes
{
    class Rhombus : BasicShape
    {
        private double height;
        private double baseLength;

        public Rhombus(double height, double baseLength)
        {
            this.Height = height;
            this.BaseLength = baseLength;
        }
        public double Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("height", "Height cannot be negative");
                }
                if (value == 0d)
                {
                    throw new ArgumentOutOfRangeException("height", "Height cannot be zero");
                }
                height = value;
            }
        }

        public double BaseLength
        {
            get { return baseLength; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("base", "Base cannot be negative");
                }
                if (value == 0d)
                {
                    throw new ArgumentOutOfRangeException("base", "Base cannot be zero");
                }
                baseLength = value;
            }
        }

        public override double CalculateArea()
        {
            return baseLength * height;
        }

        public override double CalculatePerimeter()
        {
            return baseLength * 2d + height * 2d;
        }
    }
}
