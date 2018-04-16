namespace Abstraction
{
    using System;

    using Abstraction.Interfaces;

    class Rectangle : Figure, IRectangle
    {
        private double width;

        private double height;

        public Rectangle()
            : this(0, 0)
        {
        }

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }
        public virtual double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("width", "figure's width must be positive");
                }

                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("height", "figure's height must be positive");
                }

                this.height = value;
            }
        }
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;

            return surface;
        }
    }
}
