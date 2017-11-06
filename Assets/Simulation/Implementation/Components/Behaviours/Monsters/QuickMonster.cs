using System;
using System.Linq;
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
            State = StateType.Walking;
        }

        public override void DoStep()
        {
            switch (State)
            {
                case StateType.Walking:
                    if (Transform.DistanceTo(CurrentDestination) > 100)
                    {
                        MotionController.RotateTo(CurrentDestination);
                        MotionController.StepForward();
                    }
                    else
                    {
                        GenerateNewTarget();
                        State = StateType.Shooting;
                    }
                    break;
                case StateType.Shooting:
                    if (CurrentTarget == null)
                    {
                        GenerateNewDestination();
                        State = StateType.Walking;
                    }

                    if (!Tools.Eq(0, Transform.AngleTo(CurrentTarget.GetComponent<Transform>().Position)))
                    {
                        MotionController.RotateTo(CurrentTarget.GetComponent<Transform>().Position);
                    }
                    else
                    {
                        SimpleGun.Shoot();

                        GenerateNewDestination();
                        State = StateType.Walking;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void GenerateNewDestination()
        {
            CurrentDestination = Vector2.Random(new Random(), SizeService.Size);
        }

        private void GenerateNewTarget()
        {
            CurrentTarget = GameObject.World.GameObjects
                .FirstOrDefault(o => o.HasComponent<MonsterBehaviour>() && o != GameObject);
        }
    }
}