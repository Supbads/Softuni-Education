using System.IO;
using System.Text.RegularExpressions;
using Problem_1.Point3D;

namespace Problem_3.Paths
{
    class Storage
    {
        public static void SavePathToFile(string filePath, string pathToString)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(pathToString);
            }
        }

        public static Path3D LoadPathFromFile(string filepath)
        {
            Path3D path = new Path3D();

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line = reader.ReadLine();
                const string PointPattern = @"[xyz=:\-\s](\d+(?:(?:\.|,)\d+)*)";

                while (line != null)
                {
                    MatchCollection matches = Regex.Matches(line, PointPattern);
                    if (matches.Count == 3)
                    {
                        int x = int.Parse(matches[0].Groups[1].Value);
                        int y = int.Parse(matches[1].Groups[1].Value);
                        int z = int.Parse(matches[2].Groups[1].Value);

                        Point3D point = new Point3D(x, y, z);
                        path.AddPoints(point);
                    }

                    line = reader.ReadLine();
                }
            }
            return path;
        }
    }
}
