using System;

namespace Simulation.Implementation.Geometry
{
    public static class Tools
    {
        public static float Epsilon { get { return 1e-5f; } }

        public static float TwoPi { get { return (float)Math.PI * 2; } }

        public static float NormalizeAngle(float angle)
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
    }
}