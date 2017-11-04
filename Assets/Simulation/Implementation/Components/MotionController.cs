using System;
using Simulation.Implementation.Components.Exceptions;
using Simulation.Implementation.Geometry;

namespace Simulation.Implementation.Components
{
    public class MotionController : Component
    {
        public float StraightSpeed { get; set; }
        public float SideSpeed { get; set; }

        public float RotationSpeed { get; set; }

        private Transform Transform { get; set; }

        public override void Initialize(GameObject gameObject)
        {
            base.Initialize(gameObject);

            Transform = GameObject.GetComponentUnsafe<Transform>();
        }

        public void StepLeft()
        {
            Transform.Translate(Transform.Left * SideSpeed);
        }

        public void StepRight()
        {
            Transform.Translate(Transform.Right * SideSpeed);
        }

        public void StepForward()
        {
            Transform.Translate(Transform.Forward * StraightSpeed);
        }

        public void StepBackward()
        {
            Transform.Translate(Transform.Backward * StraightSpeed);
        }

        public void Rotate(float angle)
        {
            Transform.Rotate(Tools.FitRange(angle, -RotationSpeed, RotationSpeed));
        }

        public void RotateTo(Vector2 pos)
        {
            Rotate(Transform.AngleTo(pos));
        }
    }
}