using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionOperators
{
    public struct Point2D
    {
        #region Business as usual
        public double X { get; set; }
        public double Y { get; set; }
        public Point2D(double x, double y) : this()
        {
            this.X = x;
            this.Y = y;
        }
        #endregion

    }

    public struct Point3D
    {
        #region Business as usual
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point3D(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        #endregion
        public static explicit operator Point2D(Point3D value)
        { return new Point2D(value.X, value.Y); }
        public static implicit operator Point3D(Point2D value)
        { return new Point3D(value.X, value.Y, 0D); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point2D p1 = (Point2D) new Point3D(3D, 4D, 5D);
            Point3D p2 = new Point2D(3D, 4D);
            Point3D p3 = (Point3D) new Point2D(3D, 4D);

            ////as-Schlüsselwort führt keine Konvertierungen durch
            //Point2D p4 = new Point3D(1D, 2D, 3D) as Point2D;
            //Point3D p5 = new Point2D(1D, 2D) as Point3D;
        }
    }
}
