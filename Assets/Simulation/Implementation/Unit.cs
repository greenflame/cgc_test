using System;
using Simulation.Implementation.Geometry;
using Simulation.Interfaces;

namespace Simulation.Implementation
{
    public class Unit : IUnit
    {
        public float Angle { get; set; }
        public float Radius { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Vector2 Forward
        {
            get { return Vector2.FromAngle(Angle); }
        }

        public float AngleTo(float x, float y)
        {
            return Forward.AngleTo(new Vector2(x, y) - Position);
        }

        public float AngleTo(IUnit obj)
        {
            return AngleTo(obj.X, obj.Y);
        }

        public float DistanceTo(float x, float y)
        {
            return Position.DistanceTo(new Vector2(x, y));
        }

        public float DistanceTo(IUnit obj)
        {
            return DistanceTo(obj.X, obj.Y);
        }

        public void Translate(Vector2 vec)
        {
            Position += vec;
        }

        public void Rotate(float angle)
        {
            Angle = Tools.NormalizeAngle(Angle + angle);
        }
    }
}