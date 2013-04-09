using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shape
{
    class ShapeTest
    {
        static void Main(string[] args)
        {
            Circle circ = new Circle(4);
            Triangle triangle = new Triangle(4, 7);
            Rectangle rectangle = new Rectangle(7, 8.4);

            Shape[] shapes = { circ, triangle, rectangle };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
