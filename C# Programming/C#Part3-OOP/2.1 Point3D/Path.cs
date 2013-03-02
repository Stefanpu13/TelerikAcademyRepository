using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    class Path
    {
        private List<Point3D> pointsPath;

        

        public Path(params Point3D[] points)
        {
            PointsPath = new List<Point3D>(points.Length);

            foreach (var point in points)
            {
                PointsPath.Add(point);
            }
        }

        public List<Point3D> PointsPath
        {
            get
            {
                return this.pointsPath;
            }
            set
            {
                this.pointsPath = value;
            }
        }
    }
}
