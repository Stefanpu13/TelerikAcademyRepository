using System;
using System.Linq;


namespace _1.Shape
{
    abstract class Shape
    {
        private double width;
        private double height;

        protected Shape(double width, double height) 
        {
            this.width = width;
            this.height = height;
        }

        // This form of the constructor is used to guarantee that height is equal to width
        // in the "Circle" class.
        protected Shape(double width) : this(width, width) { }

        
        protected Shape() : this(1) { }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
