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

        public float Angle
        {
            get { return new Vector2(1, 0).AngleTo(this); }
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
            return new Vector2(v.X / a, v.Y / a);
        }

        public float Dot(Vector2 other)
        {
            return X * other.X + Y * other.Y;
        }

        public float Cross(Vector2 other)
        {
            return X * other.Y - Y * other.X;
        }

        public Vector2 Rotate(float angle)
        {
            float cs = (float) Math.Cos(angle);
            float sn = (float) Math.Sin(angle);

            return new Vector2(X * cs - Y * sn, X * sn + Y * cs);
        }

        public static Vector2 FromAngle(float angle)
        {
            return new Vector2(1, 0).Rotate(angle);
        }

        public float AngleTo(Vector2 other)
        {
            var dot = other.Normalized.Dot(Normalized);
            var cross = Cross(other);

            var angle = (float)Math.Acos(Tools.FitRange(dot, -1, 1));

            if (Math.Abs(cross) > float.Epsilon)
            {
                angle *= Math.Sign(cross);
            }

            return angle;
        }
        
        public float DistanceTo(Vector2 other)
        {
            return (this - other).Length;
        }

        public static Vector2 Random(Random r, Vector2 max)
        {
            return new Vector2((float) (r.NextDouble() * max.X), (float) (r.NextDouble() * max.Y));
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", X, Y);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
            {
                return false;
            }

            return Equals((Vector2)obj);
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

    }
}