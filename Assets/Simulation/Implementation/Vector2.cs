using System;

namespace Simulation.Implementation
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public float Length
        {
            get { return (float)Math.Sqrt(Dot(this)); }
        }

        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public float Dot(Vector2 other)
        {
            return X * other.X + Y * other.Y;
        }

    }
}