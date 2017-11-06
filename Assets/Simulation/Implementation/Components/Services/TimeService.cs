namespace Simulation.Implementation.Components.Services
{
    public class TimeService : Service
    {
        public int Tick { get; set; }

        public override void Initialize()
        {
            Tick = 0;
        }

        public override void DoStep()
        {
            Tick++;
        }
    }
}