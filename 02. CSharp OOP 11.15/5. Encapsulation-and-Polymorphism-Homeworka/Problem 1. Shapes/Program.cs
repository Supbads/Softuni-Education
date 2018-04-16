using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_1.Shapes.Interfaces;

namespace Problem_1.Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IShape> shapesList = new List<IShape>();
            shapesList.Add(new Rhombus(7.6,9.1));
            shapesList.Add(new Circle(11.3));
            shapesList.Add(new Rectangle(15, 30.4));

            foreach (IShape shape in shapesList)
            {
                Console.Write("This shape has an area of: ");
                Console.WriteLine(shape.CalculateArea());
                Console.Write("This shape has a perimeter of: ");
                Console.WriteLine(shape.CalculatePerimeter());
            }
            try
            {
                shapesList.Add(new Circle(0));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
