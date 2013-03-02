using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    class Distance
    {
        public static double CalculateDistance(Point3D pointOne, Point3D pointTwo)
        {
            double distance;
            double xDistnace = Math.Pow(2, pointOne.CoordX - pointTwo.CoordX);
            double yDistnace = Math.Pow(2, pointOne.CoordY - pointTwo.CoordY);
            double zDistnace = Math.Pow(2, pointOne.CoordZ - pointTwo.CoordZ);

            distance = Math.Sqrt(xDistnace + yDistnace + zDistnace);

            return distance;
        }
    }
}
