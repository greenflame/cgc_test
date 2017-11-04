using System;
using Simulation.Implementation.Components.Exceptions;
using Simulation.Implementation.Geometry;

namespace Simulation.Implementation.Components.Behaviours
{
    public class QuickMonster : MonsterBehaviour
    {
        private enum StateType
        {
            Walking,
            Shooting
        }

        private StateType State { get; set; }
        private Vector2 CurrentDestination { get; set; }
        private GameObject CurrentTarget { get; set; }
        
        // Components
        private Transform Transform { get; set; }
        private MotionController MotionController { get; set; }


        public override void Initialize(GameObject gameObject)
        {
            base.Initialize(gameObject);

            Transform = GameObject.GetComponentUnsafe<Transform>();
            MotionController = GameObject.GetComponentUnsafe<MotionController>();

            GenerateNewDestination();
        }

        public override void DoStep()
        {
            if (Transform.DistanceTo(CurrentDestination) < 100)
            {
                GenerateNewDestination();
            }

            MotionController.RotateTo(CurrentDestination);
            MotionController.StepForward();
        }

        private void GenerateNewDestination()
        {
            CurrentDestination = Vector2.Random(new Random(), GameObject.World.Size);
        }
    }
}