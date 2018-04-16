using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem_1.Point3D
{
    class Point3D
    {
        static readonly Point3D StartingPoint = new Point3D(0,0,0);
        private int x;
        private int y;
        private int z;

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Z
        {
            get { return z; }
            set { z = value; }
        }

        public static Point3D GetStartingPoint()
        {
            return StartingPoint;
        }

        public override string ToString()
        {
            return string.Format("Current point coordinates:\nX: {0}  Y: {1}  Z: {2}",this.x,this.y,this.z);
        }
    }
}
