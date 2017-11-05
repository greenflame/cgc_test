using System;

namespace Simulation.Implementation.Geometry
{
    public static class Tools
    {
        public static double Epsilon { get { return 1e-5f; } }

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
    }
}