using System;

namespace Methods
{
    public static class GeometryUtilities
    {
        /// <summary>
        /// Calculates the distance between two points represented through their 
        /// two - dimensional coordinates.
        /// </summary>
        /// <param name="x1">The x - coordinate of the first point.</param>
        /// <param name="y1">The y - coordinate of the first point.</param>
        /// <param name="x2">The x - coordinate of the second point.</param>
        /// <param name="y2">The y - coordinate of the second point.</param>
        /// <returns>The distance between the two points.</returns>
        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        /// <summary>
        /// Calculates the area of a give n triangle using the Heron`s formula.
        /// </summary>
        /// <param name="a">The first side of the triangle.</param>
        /// <param name="b">The second side of the triangle.</param>
        /// <param name="c">The third side of the triangle.</param>
        /// <returns>The area of the triangle.</returns>
        /// <exception cref="ArgumentException">Any of the side is non-positive -or-
        /// The sides do not forma  valid triangle.</exception>
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                string message = "Sides must be positive.";
                throw new ArgumentException(message);
            }

            bool valuesAreValidTriangleSides = CanFormValidTriangle(a, b, c);
            if (!valuesAreValidTriangleSides)
            {
                string message = "Sides can not form a valid tringle" +
                    "because they do not satisfy triangle inequality theorem.";
                throw new ArgumentException(message);
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter *
                (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        /// <summary>
        /// Checks if a given line, presented by the two - dimensional coordinates 
        /// of two points is horizontal.
        /// </summary>
        /// <param name="x1">The x - coordinate of the first point.</param>
        /// <param name="y1">The y - coordinate of the first point.</param>
        /// <param name="x2">The x - coordinate of the second point.</param>
        /// <param name="y2">The y - coordinate of the second point.</param>
        /// <returns>True if line is horizlontal, false otherwise.</returns>
        /// <exception cref="ArgumentException">The two points coinside.</exception>
        /// <remarks>The line is considered horizontal if the y - coordintes
        /// of the two points are equal.</remarks>
        public static bool IsHorizontal(double x1, double y1, double x2, double y2)
        {
            bool pointsCoinside = PointsCoinside(x1, x2, y1, y2);

            if (pointsCoinside)
            {
                throw new ArgumentException("Points coinside. No line is formed.");
            }

            return y1 == y2;
        }

        /// <summary>
        /// Checks if a given line, presented by the two - dimensional coordinates 
        /// of two points is vertical.
        /// </summary>
        /// <param name="x1">The x - coordinate of the first point.</param>
        /// <param name="y1">The y - coordinate of the first point.</param>
        /// <param name="x2">The x - coordinate of the second point.</param>
        /// <param name="y2">The y - coordinate of the second point.</param>
        /// <returns>True if line is vertical, false otherwise.</returns>
        /// <exception cref="ArgumentException">The two points coinside.</exception>
        /// /// <remarks>The line is considered vertival if the x - coordintes
        /// of the two points are equal.</remarks>
        public static bool IsVertical(double x1, double y1, double x2, double y2)
        {
            bool pointsCoinside = PointsCoinside(x1, x2, y1, y2);

            if (pointsCoinside)
            {
                throw new ArgumentException("Points coinside. No line is formed.");
            }

            return x1 == x2;
        }

        /// <summary>
        /// Checks if the tree sides satisfy the trianlge inequality theorem.
        /// </summary>
        /// <param name="a">The first side.</param>
        /// <param name="b">The second side.</param>
        /// <param name="c">The third side.</param>
        /// <returns>True if sides can form a triangle, false otherwise.</returns>
        private static bool CanFormValidTriangle(double a, double b, double c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the coordinates of two two - dimensional points are equal.
        /// </summary>
        /// <param name="x1">The x - coordinate of the first point.</param>
        /// <param name="y1">The y - coordinate of the first point.</param>
        /// <param name="x2">The x - coordinate of the second point.</param>
        /// <param name="y2">The y - coordinate of the second point.</param>
        /// <returns>True if two points coniside, false otherwise.</returns>
        private static bool PointsCoinside(double x1, double y1, double x2, double y2)
        {
            return x1 == x2 && y1 == y2;
        }
    }
}
