using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Point3D pointOne = new Point3D(3, 3, 4.5);
            Point3D pointTwo = Point3D.ZeroPoint;
            Point3D pointThree = new Point3D(5.45, -45, 7);

            Path points = new Path(pointOne, pointTwo, pointThree);

            foreach (var point in points.PointsPath)
            {
                Console.WriteLine(point);
            }

            PathStorage.SavePath(points.PointsPath, "path.txt");
            List<Point3D> extractedPoints = PathStorage.LoadPath("path.txt", 1);

            foreach (var point in extractedPoints)
            {
                Console.WriteLine(point);
            }
        }
    }
}
