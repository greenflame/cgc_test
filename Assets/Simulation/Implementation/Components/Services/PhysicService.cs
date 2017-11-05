namespace Simulation.Implementation.Components.Services
{
    public class PhysicService : Service
    {
        private SizeService SizeService { get; set; }

        public override void Initialize()
        {
            SizeService = GameObject.World
                .GetObject<SizeService>()
                .GetComponent<SizeService>();
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