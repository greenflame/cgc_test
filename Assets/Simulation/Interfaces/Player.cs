namespace Simulation.Interfaces
{
    public abstract class Player
    {
        public IWorld World { get; private set; }
        public ISelfControl SelfControl { get; private set; }

        public Player(IWorld world, ISelfControl selfControl)
        {
            World = world;
            SelfControl = selfControl;
        }

        public abstract void Init();
        public abstract void Move();
    }
}
