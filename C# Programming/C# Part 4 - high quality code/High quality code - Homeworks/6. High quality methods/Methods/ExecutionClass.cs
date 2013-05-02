using System;

namespace Methods
{
    public class ExecutionClass
    {
        public static void Main()
        {
            double a = 3;
            double b = 4;
            double c = 5;

            double area = GeometryUtilities.CalculateTriangleArea(a, b, c);

            Console.WriteLine(area);
        }
    }
}
