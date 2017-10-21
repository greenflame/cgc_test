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
            //SelfControl.TurnTo(World.Height / 2, World.Width / 2);
            SelfControl.StepForward();
        }
    }
}