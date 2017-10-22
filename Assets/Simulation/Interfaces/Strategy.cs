namespace Simulation.Interfaces
{
    public abstract class Strategy
    {
        public IWorld World { get; private set; }
        public ISelfControl SelfControl { get; private set; }

        public Strategy(IWorld world, ISelfControl selfControl)
        {
            World = world;
            SelfControl = selfControl;
        }

        public abstract void Init();
        public abstract void Move();
    }
}
