using System;
using Simulation.Implementation.Geometry;
using Simulation.Interfaces;

namespace Simulation.Implementation
{
    public class MovableUnit : Unit, IMovableUnit
    {
        public float LeftSpeed { get; set; }
        public float RightSpeed { get; set; }
        public float ForwardSpeed { get; set; }
        public float BackSpeed { get; set; }

        public float RotationSpeed { get; set; }


        public void StepLeft()
        {
            Translate(Vector2.FromAngle(Angle - (float)Math.PI / 2) * ForwardSpeed);
        }

        public void StepRight()
        {
            Translate(Vector2.FromAngle(Angle + (float)Math.PI / 2) * ForwardSpeed);
        }

        public void StepForward()
        {
            Translate(Vector2.FromAngle(Angle) * ForwardSpeed);
        }

        public void StepBack()
        {
            Translate(Vector2.FromAngle(Angle + (float)Math.PI) * ForwardSpeed);
        }

        public void RotateConsiderSpeed(float angle)
        {
            angle = Math.Min(angle, RotationSpeed);
            angle = Math.Max(angle, -RotationSpeed);

            Rotate(angle);
        }
    }
}