using Simulation.Implementation.Geometry;

namespace Simulation.Implementation.Components
{
    public class MotionController : Component
    {
        public double StraightSpeed { get; set; }
        public double SideSpeed { get; set; }

        public double RotationSpeed { get; set; }

        private Transform Transform { get; set; }

        public override void Initialize()
        {
            Transform = GameObject.GetComponent<Transform>();
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

        public void Rotate(double angle)
        {
            Transform.Rotate(Tools.FitRange(angle, -RotationSpeed, RotationSpeed));
        }

        public void RotateTo(Vector2 pos)
        {
            Rotate(Transform.AngleTo(pos));
        }
    }
}