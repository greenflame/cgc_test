using System;

namespace Simulation.Implementation.Geometry
{
    public static class Tools
    {
        public static double Epsilon { get { return 1e-5f; } }

        // todo delete
        public static double HalfPi { get { return Math.PI / 2; } }

        public static double TwoPi { get { return Math.PI * 2; } }

        public static double NormalizeAngle(double angle)
        {
            while (angle <= -Math.PI)
            {
                angle += TwoPi;
            }

            while (angle > Math.PI)
            {
                angle -= TwoPi;
            }

            return angle;
        }

        public static double FitRange(double val, double min, double max)
        {
            val = Math.Min(val, max);
            val = Math.Max(val, min);

            return val;
        }

        public static bool Eq(double d1, double d2)
        {
            return Math.Abs(d1 - d2) < Epsilon;
        }

        public static bool Gt(double d1, double d2)
        {
            return d1 > d2 && !Eq(d1, d2);
        }

        public static bool Lt(double d1, double d2)
        {
            return d1 < d2 && !Eq(d1, d2);
        }

        public static bool Ge(double d1, double d2)
        {
            return d1 > d2 || Eq(d1, d2);
        }

        public static bool Le(double d1, double d2)
        {
            return d1 < d2 || Eq(d1, d2);
        }
    }
}