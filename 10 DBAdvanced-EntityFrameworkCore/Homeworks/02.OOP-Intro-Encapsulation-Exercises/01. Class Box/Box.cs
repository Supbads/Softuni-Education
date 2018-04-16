using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Class_Box
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return this.length; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double CalculateVolume()
        {
            double volume = Length * Width * Height;

            return volume;
        }

        public double CalculateLateralSurfaceAre()
        {
            double lateralSurface = (2 * Length * Height) + (2 * Width * Height);

            return lateralSurface;
        }

        public double CalculateSurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

    }
}
