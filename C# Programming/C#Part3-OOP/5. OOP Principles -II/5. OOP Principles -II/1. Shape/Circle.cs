using System;
using System.Linq;


namespace _1.Shape
{
    class Circle:Shape
    {
        private static readonly double PI = Math.PI;

        public Circle(double width) : base(width) { }

        public override double CalculateSurface()
        {
            double surface = PI * Math.Pow(this.Width, 2) / 4;
            return surface;
        }
    }
}
