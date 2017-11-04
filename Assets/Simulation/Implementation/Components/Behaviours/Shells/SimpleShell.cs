using Simulation.Implementation.Components.Services;

namespace Simulation.Implementation.Components.Behaviours.Shells
{
    class SimpleShell : ShellBehaviour
    {
        private Transform Transform { get; set; }
        private MotionController MotionController { get; set; }

        private PhysicService PhysicService { get; set; }

        public override void Initialize()
        {
            Transform = GameObject.GetComponent<Transform>();
            MotionController = GameObject.GetComponent<MotionController>();

            PhysicService = GameObject.World
                .GetObject<PhysicService>()
                .GetComponent<PhysicService>();

            base.Initialize();
        }

        public override void DoStep()
        {
            MotionController.StepForward();

            if (PhysicService.DoesTransformTouchWalls(Transform))
            {
                GameObject.World.DestroyObject(GameObject);
            }

            // todo damage
        }
    }
}
