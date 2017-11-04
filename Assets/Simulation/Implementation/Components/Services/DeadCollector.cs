using System.Linq;

namespace Simulation.Implementation.Components.Services
{
    public class DeadCollector : Service
    {
        public override void DoStep()
        {
            var dead = GameObject.World
                .GetObjects<Health>()
                .Where(o => o.GetComponent<Health>().Current == 0)
                .ToList();

            dead.ForEach(d => GameObject.World.DestroyObject(d));
        }
    }
}