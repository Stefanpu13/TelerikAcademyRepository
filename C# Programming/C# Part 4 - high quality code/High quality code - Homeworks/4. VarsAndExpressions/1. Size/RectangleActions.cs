namespace _4.VarsDataExpressionsUse
{
    using System;
    using System.Linq;

    public static class RectangleActions
    {
        private const int HalfCircleDegrees = 180;
        private const double FullCircleDegrees = 360;
        private const double ZeroDegrees = 0;

        /// <summary>
        /// Gets the bounding box of this rectangle, rotated with a given angle.
        /// </summary>
        /// <param name="rectangle">The rotated rectangle.</param>
        /// <param name="rotationAngle">The angle of rotation,
        /// an angle between 0 and 360 measured in degrees.</param>
        /// <returns>The bounding box of the rotated rectangle.</returns>   
        /// <remarks>Rotation angle is measured in degrees because the bounding box sides
        /// formula uses angle in degrees. </remarks>
        /// <exception cref="ArgumentException">The angle is less than 0 or more than 360.</exception>
        /// <exception cref="ArgumentNullException">Rectangle is null.</exception>        
        public static Rectangle GetBoundingBox(Rectangle rectangle, double rotationAngle)
        {
            if (rectangle != null)
            {
                if (rotationAngle <= FullCircleDegrees && rotationAngle >= ZeroDegrees)
                {
                    double boundingBoxWidth = CalculateBoundingBoxWidth(rotationAngle, rectangle);
                    double boundingBoxHeight = CalculateBoundingBoxHeight(rotationAngle, rectangle);

                    Rectangle boundingBox = new Rectangle(boundingBoxWidth, boundingBoxHeight);
                    return boundingBox;
                }
                else
                {
                    string message = "Angle must be a value between 0 and 360.";
                    throw new ArgumentException(message);
                }
            }
            else
            {
                string message = "Can not get the bounding box of null.";
                throw new ArgumentNullException("rectangle", message);
            }
        }

        /// <summary>
        /// Calculates the height of the bounding box of the rotated rectangle.
        /// </summary>
        /// <param name="rotationAngle">The angle of rotation in degrees.</param>
        /// <param name="rectangle">The rotated rectangle.</param>
        /// <returns>The height of the bounding box.</returns>
        private static double CalculateBoundingBoxHeight(double rotationAngle, Rectangle rectangle)
        {
            /*
             * rotationAngle is in degrees, but "Math.Sin" and"Math.Cos" take as parameter
             * an angle in radians, so convertion is necessary.
             */
            double angleToRadians = rotationAngle * Math.PI / HalfCircleDegrees;
            double rotationAngleCos = Math.Abs(Math.Cos(angleToRadians));
            double rotationAngleSin = Math.Abs(Math.Sin(angleToRadians));

            double boundedBoxHeight =
                rotationAngleSin * rectangle.Width + rotationAngleCos * rectangle.Height;

            return boundedBoxHeight;
        }

        /// <summary>
        /// Calculates the width of the bounding box of the rotated rectangle.
        /// </summary>
        /// <param name="rotationAngle">The angle of rotation in degrees.</param>
        /// <param name="rectangle">The rotated rectangle.</param>
        /// <returns>The width of the bounding box.</returns>
        private static double CalculateBoundingBoxWidth(double rotationAngle, Rectangle rectangle)
        {
            /*
             * rotationAngle is in degrees, but "Math.Sin" and"Math.Cos" take as parameter
             * an angle in radians, so convertion is necessary.
             */
            double angleToRadians = rotationAngle * Math.PI / HalfCircleDegrees;
            double rotationAngleCos = Math.Abs(Math.Cos(angleToRadians));
            double rotationAngleSin = Math.Abs(Math.Sin(angleToRadians));

            double boundingBoxWidth =
                rotationAngleCos * rectangle.Width + rotationAngleSin * rectangle.Height;

            return boundingBoxWidth;
        }
    }
}
