using System;

namespace RandomWalk
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public double R { get; private set; }
        public double Theta { get; private set; }
        public double Phi { get; private set; }

        public Point Add(Point point) => Cartesian(X + point.X, Y + point.Y, Z + point.Z);

        public static Point Cartesian(double x, double y, double z)
        {
            double r = 0;
            double theta = 0;
            double phi = 0;

            try
            {
                r = Math.Sqrt(x * x + y * y + z * z);
            }
            catch { }

            try
            {
                theta = Math.Atan(y / z);
            }
            catch { }

            try
            {
                phi = Math.Acos(z / r);
            }
            catch { }

            return new Point()
            {
                X = x,
                Y = y,
                Z = z,
                R = r,
                Theta = theta,
                Phi = phi
            };
        }

        public static Point Spherical(double r, double theta, double phi)
        {
            double x = 0;
            double y = 0;
            double z = 0;

            try
            {
                x = r * Math.Sin(theta) * Math.Cos(phi);
            }
            catch { }

            try
            {
                y = r * Math.Sin(theta) * Math.Sin(phi);
            }
            catch { }

            try
            {
                z = r * Math.Cos(theta);
            }
            catch { }

            return new Point()
            {
                X = x,
                Y = y,
                Z = z,
                R = r,
                Theta = theta,
                Phi = phi
            };
        }
    }
}
