namespace _4.VarsDataExpressionsUse
{
    using System;

    public class Rectangle
    {
        private double width;
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class
        /// with the specified width and height.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        /// <exception cref=" ArgumentException">Height is less than or equal to zero.</exception>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height must be greater than zero.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        /// <exception cref="ArgumentException">Width is less than or equal to zero.</exception>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width must be greater than zero.");
                }
            }
        }
    }
}
