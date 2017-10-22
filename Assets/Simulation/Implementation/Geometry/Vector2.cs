using Simulation.Interfaces;
using System;

namespace Simulation.Implementation.Geometry
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public float Length
        {
            get { return (float)Math.Sqrt(Dot(this)); }
        }

        public Vector2 Normalized
        {
            get { return this / Length; }
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

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
            {
                return false;
            }

            return Equals((Vector2) obj);
        }

        protected bool Equals(Vector2 other)
        {
            return Math.Abs(X - other.X) < Tools.Epsilon && Math.Abs(Y - other.Y) < Tools.Epsilon;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator *(Vector2 v, float a)
        {
            return new Vector2(v.X * a, v.Y * a);
        }

        public static Vector2 operator /(Vector2 v, float a)
        {
            return v * (1f / a);
        }

        public float Dot(Vector2 other)
        {
            return X * other.X + Y * other.Y;
        }

        public float Cross(Vector2 other)
        {
            return X * other.Y - Y * other.X;
        }

        public static Vector2 FromAngle(float angle)
        {
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        public float AngleTo(Vector2 other)
        {
            var dot = other.Normalized.Dot(Normalized);
            var cross = Cross(other);

            var angle = (float)Math.Acos(Math.Min(1, dot));

            if (Math.Abs(cross) > float.Epsilon)
            {
                angle *= Math.Sign(cross);
            }

            return angle;
        }

        public static Vector2 FromUnit(IUnit unit)
        {
            return new Vector2(unit.X, unit.Y);
        }

        public float DistanceTo(Vector2 other)
        {
            return (this - other).Length;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", X, Y);
        }
    }
}