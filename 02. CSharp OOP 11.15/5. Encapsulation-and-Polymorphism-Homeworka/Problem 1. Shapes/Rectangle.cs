using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Shapes
{
    class Rectangle : BasicShape
    {
        private double width;
        private double heigth;

        public Rectangle(double width, double heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("width","width cannot be negative");
                }
                if (value == 0d)
                {
                    throw new ArgumentOutOfRangeException("width", "width cannot be zero");
                }
                width = value;
            }
        }

        public double Heigth
        {
            get { return heigth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("heigth", "heigth cannot be negative");
                }
                if (value == 0d)
                {
                    throw new ArgumentOutOfRangeException("heigth", "heigth cannot be zero");
                }
                heigth = value;
            }
        }

        public override double CalculateArea()
        {
            return width*heigth;
        }

        public override double CalculatePerimeter()
        {
            return width*2 + heigth*2;
        }
    }
}
