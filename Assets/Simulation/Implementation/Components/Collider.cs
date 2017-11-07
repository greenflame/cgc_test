namespace Simulation.Implementation.Components
{
    public class Collider : Component
    {
        public int Mass { get; set; }

        public override void Initialize()
        {
            GameObject.RequireComponent<Transform>();
        }
    }
}