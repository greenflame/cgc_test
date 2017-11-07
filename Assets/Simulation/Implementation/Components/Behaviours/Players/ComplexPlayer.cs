namespace Simulation.Implementation.Components.Behaviours.Players
{
    public class ComplexPlayer : PlayerBehaviour
    {
        private MotionController MotionController { get; set; }

        public override void Initialize()
        {
            GameObject.RequireComponent<MotionController>();

            MotionController = GameObject.GetComponent<MotionController>();
        }

        public override void DoStep()
        {
            MotionController.StepForward();
            MotionController.Rotate(10);
        }
    }
}