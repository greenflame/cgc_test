using Simulation.Interfaces;
using System;

namespace Simulation.Implementation.Geometry
{
    public class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Length
        {
            get { return Math.Sqrt(Dot(this)); }
        }

        public Vector2 Normalized
        {
            get { return this / Length; }
        }

        public double Angle
        {
            get { return new Vector2(1, 0).AngleTo(this); }
        }

        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(double x, double y)
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

        public static Vector2 operator *(Vector2 v, double a)
        {
            return new Vector2(v.X * a, v.Y * a);
        }

        public static Vector2 operator /(Vector2 v, double a)
        {
            return new Vector2(v.X / a, v.Y / a);
        }

        public double Dot(Vector2 other)
        {
            return X * other.X + Y * other.Y;
        }

        public double Cross(Vector2 other)
        {
            return X * other.Y - Y * other.X;
        }

        public Vector2 Rotate(double angle)
        {
            double cs = Math.Cos(angle);
            double sn = Math.Sin(angle);

            return new Vector2(X * cs - Y * sn, X * sn + Y * cs);
        }

        public static Vector2 FromAngle(double angle)
        {
            return new Vector2(1, 0).Rotate(angle);
        }

        public double AngleTo(Vector2 other)
        {
            var dot = other.Normalized.Dot(Normalized);
            var cross = Cross(other);

            var angle = Math.Acos(Tools.FitRange(dot, -1, 1));

            if (Math.Abs(cross) > double.Epsilon)
            {
                angle *= Math.Sign(cross);
            }

            return angle;
        }
        
        public double DistanceTo(Vector2 other)
        {
            return (this - other).Length;
        }

        public static Vector2 Random(Random r, Vector2 max)
        {
            return new Vector2(r.NextDouble() * max.X, r.NextDouble() * max.Y);
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