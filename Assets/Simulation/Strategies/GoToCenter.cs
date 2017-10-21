using Simulation.Interfaces;

namespace Simulation.Strategies
{
    public class GoToCenter : Player
    {
        public GoToCenter(IWorld world, ISelfControl selfControl) : base(world, selfControl)
        {
        }

        public override void Init()
        {
            SelfControl.SetName("Go To Center");
        }

        public override void Move()
        {
            if (SelfControl.DistanceTo(World.Width / 2, World.Height / 2) > 200)
            {
                SelfControl.TurnTo(World.Width / 2, World.Height / 2);
            }
            else
            {
                SelfControl.TurnTo(0, 0);
            }

            SelfControl.StepForward();
        }
    }
}