using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Point
{
    class PathStorage
    {
        //Loads the path, written as a sequence of points, from the specified line.
        public static List<Point3D> LoadPath(string fileName, int lineNumber)
        {
            List<Point3D> pointsPath = new List<Point3D>();
            StreamReader sr;

            try
            {
                //If path== null then "if" block is not entered.
                //So, no need to catch ArgumentNullException for streamReader.
                //Does File.Exists include dirextory that is not found? 
                if (File.Exists(fileName))
                {
                    using (sr = new StreamReader(fileName))
                    {
                        string pointsPathData;
                        string pointPattern = @"{.*?}";

                        pointsPathData = ReadSearchedLine(lineNumber, sr);

                        MatchCollection pointsMatches = Regex.Matches(pointsPathData, pointPattern);
                        pointsPath = GetPoints(pointsMatches);
                    }
                }

            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.ParamName + aore.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }


            return pointsPath;
        }

        private static string ReadSearchedLine(int lineNumber, StreamReader sr)
        {
            int currentLine = 1;
            string pointsPathData = sr.ReadLine();            

            //While the searched line is not reached
            while (currentLine != lineNumber)
            {
                //If there are no more lines to read
                if ((pointsPathData = sr.ReadLine()) == null)
                {
                    string message = " does not exist.";
                    string paramName = "line";
                    throw new ArgumentOutOfRangeException(paramName, message);
                }
                lineNumber++;
            }

            return pointsPathData;
        }

        //Extracts the points found in the match collection.
        private static List<Point3D> GetPoints(MatchCollection pointsMatches)
        {
            List<Point3D> points = new List<Point3D>(pointsMatches.Count);

            foreach (Match pointString in pointsMatches)
            {
                //The chars used as delimiters are based on the "ToString" method of the 
                //"PointeD" class.
                string[] pointCoords = pointString.Value.Split(new char[] { ';', ' ', '{','}' },
                    StringSplitOptions.RemoveEmptyEntries);

                Point3D point = new Point3D();
                
                InitializePointCoordinates( ref point, pointCoords);
                points.Add(point);
            }

            return points;
        }

        private static void InitializePointCoordinates(ref Point3D point, string[] pointCoords)
        {
            point.CoordX = double.Parse(pointCoords[0]);
            point.CoordY = double.Parse(pointCoords[1]);
            point.CoordZ = double.Parse(pointCoords[2]);
        }

        public static void SavePath(List<Point3D> pointsPath, string fileName)
        {
            StreamWriter sw;
            string pointsPathToString = GetPointsPathString(pointsPath);

            if (fileName != null)
            {
                using (sw = File.AppendText(fileName))
                {
                    sw.WriteLine(pointsPathToString);
                }
            }
        }

        private static string GetPointsPathString(List<Point3D> pointsPath)
        {
            StringBuilder pathStringBuilder = new StringBuilder();

            foreach (var point in pointsPath)
            {
                pathStringBuilder.Append(point + " ");
            }

            return pathStringBuilder.ToString();
        }
    }
}
