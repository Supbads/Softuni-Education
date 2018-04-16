using System;
using System.Collections.Generic;
using System.Text;
using Problem_1.Point3D;

namespace Problem_3.Paths
{
    class Path3D
    {
        private readonly List<Point3D> path = new List<Point3D>();

        public Path3D(params Point3D[] list)
        {
            this.AddPoints(list);
        }

        public List<Point3D> Path
        {
            get { return this.path; }
        }

        public void AddPoints(params Point3D[] list)
        {
            foreach (var point3D in list)
            {
                this.path.Add(point3D);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Path: "+Environment.NewLine);
            for (int i = 0; i < this.Path.Count; i++)
            {
                result.AppendFormat("point{0}: x={1} y={2} z={3}{4}", i + 1, this.Path[i].X, this.Path[i].Y, this.Path[i].Z,Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
