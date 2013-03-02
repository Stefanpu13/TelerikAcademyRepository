using System;
using System.Linq;


namespace Point
{
    struct Point3D
    {
        private double coordX;
        private double coordY;
        private double coordZ;
        private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z)
        {
            this.coordX = x;
            this.coordY = y;
            this.coordZ = z;
        }

        public double CoordX
        {
            get
            {
                return this.coordX;
            }
            set
            {
                this.coordX = value;
            }
        }

        public double CoordY
        {
            get
            {
                return this.coordY;
            }
            set
            {
                this.coordY = value;
            }
        }

        public double CoordZ
        {
            get
            {
                return this.coordZ;
            }
            set
            {
                this.coordZ = value;
            }
        }

        public static Point3D ZeroPoint
        {
            get { return zeroPoint; }
        }

        public override string ToString()
        {
            string point3DString = "{" + this.CoordX + "; " + this.CoordY + "; " + this.CoordZ + "}";
            return point3DString;
        }
    }
}
