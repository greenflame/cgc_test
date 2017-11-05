using System;
using System.Collections.Generic;
using System.Linq;
using Simulation.Implementation.Geometry;
using Simulation.Interfaces;

namespace Simulation.Implementation.Components
{
    public class Transform : Component
    {
        public Vector2 Position { get; set; }
        public double Angle { get; set; }
        public double Radius { get; set; }

        public Vector2 Forward
        {
            get { return Vector2.FromAngle(Angle); }
        }

        public Vector2 Right
        {
            get { return Vector2.FromAngle(Angle).Rotate(Tools.HalfPi); }
        }

        public Vector2 Left
        {
            get { return Vector2.FromAngle(Angle).Rotate(-Tools.HalfPi); }
        }

        public Vector2 Backward
        {
            get { return Vector2.FromAngle(Angle).Rotate(Math.PI); }
        }

        public double DistanceTo(Vector2 target)
        {
            return Position.DistanceTo(target);
        }

        public double AngleTo(Vector2 target)
        {
            return Forward.AngleTo(target - Position);
        }
        
        public void Translate(Vector2 vec)
        {
            Position += vec;
        }

        public void Rotate(double angle)
        {
            Angle = Tools.NormalizeAngle(Angle + angle);
        }
    }
}