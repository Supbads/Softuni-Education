using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_1.Shapes.Interfaces;

namespace Problem_1.Shapes
{
    abstract class BasicShape : IShape
    {
        public abstract double CalculateArea();
        abstract public double CalculatePerimeter();
    }
}
