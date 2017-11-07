using System.Linq;
using Simulation.Implementation.Geometry;

namespace Simulation.Implementation.Components.Services
{
    public class PhysicService : Service
    {
        public int Iterations { get; set; }

        private SizeService SizeService { get; set; }

        public override void Initialize()
        {
            SizeService = GameObject.World
                .GetObject<SizeService>()
                .GetComponent<SizeService>();
        }

        public override void DoStep()
        {
            ProcessCollisions();
        }

        private void ProcessCollisions()
        {
            var colliders = GameObject.World.CapturedGameObjects
                .Where(o => o.HasComponent<Collider>())
                .ToList();

            for (int iterationIndex = 0; iterationIndex < Iterations; iterationIndex++)
            {
                for (var i = 0; i < colliders.Count - 1; i++)
                {
                    for (var j = i + 1; j < colliders.Count; j++)
                    {
                         ProcessObj2ObjCollisions(colliders[i], colliders[j]);
                    }
                }

                foreach (var collider in colliders)
                {
                    ProcessObj2WallsCollision(collider);
                }
            }
        }

        private void ProcessObj2ObjCollisions(GameObject o1, GameObject o2)
        {
            Transform t1 = o1.GetComponent<Transform>();
            Transform t2 = o2.GetComponent<Transform>();

            Collider c1 = o1.GetComponent<Collider>();
            Collider c2 = o2.GetComponent<Collider>();

            if (Tools.Ge(t1.DistanceTo(t2.Position), t1.Radius + t2.Radius))
            {
                return;
            }

            int massSumm = c1.Mass + c2.Mass;
            double dist = t1.Radius + t2.Radius - t1.DistanceTo(t2.Position);

            Vector2 r1 = (t1.Position - t2.Position).Normalized * dist / massSumm * c2.Mass;
            Vector2 r2 = (t2.Position - t1.Position).Normalized * dist / massSumm * c1.Mass;

            t1.Translate(r1);
            t2.Translate(r2);
        }

        private void ProcessObj2WallsCollision(GameObject o)
        {
            // todo
        }

        public bool DoesTransformTouchWalls(Transform transform)
        {
            return transform.Position.X < transform.Radius ||
                   transform.Position.X > SizeService.Size.X - transform.Radius ||
                   transform.Position.Y < transform.Radius ||
                   transform.Position.Y > SizeService.Size.Y - transform.Radius;
        }
    }
}