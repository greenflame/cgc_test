using System;
using Simulation.Implementation.Components.Guns;
using Simulation.Implementation.Components.Services;
using Simulation.Implementation.Geometry;

namespace Simulation.Implementation.Components.Behaviours.Monsters
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
        private SimpleGun SimpleGun { get; set; }

        private SizeService SizeService { get; set; }

        public override void Initialize()
        {
            Transform = GameObject.GetComponent<Transform>();
            MotionController = GameObject.GetComponent<MotionController>();
            SimpleGun = GameObject.GetComponent<SimpleGun>();

            SizeService = GameObject.World
                .GetObject<SizeService>()
                .GetComponent<SizeService>();

            GenerateNewDestination();
        }

        public override void DoStep()
        {
            if (Transform.DistanceTo(CurrentDestination) < 100)
            {
                GenerateNewDestination();
                SimpleGun.Shoot();
            }

            MotionController.RotateTo(CurrentDestination);
            MotionController.StepForward();
        }

        private void GenerateNewDestination()
        {
            CurrentDestination = Vector2.Random(new Random(), SizeService.Size);
        }
    }
}