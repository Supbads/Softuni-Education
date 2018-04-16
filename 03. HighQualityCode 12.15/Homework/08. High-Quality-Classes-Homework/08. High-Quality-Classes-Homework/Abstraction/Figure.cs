namespace Abstraction
{
    using Abstraction.Interfaces;

    abstract class Figure : IFigure
    {
        public Figure()
        {
        }

        public abstract double CalcPerimeter();
        public abstract double CalcSurface();

    }
}
