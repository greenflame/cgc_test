using System;
using Simulation.Interfaces;

namespace Simulation.Strategies
{
    public class GoToCenter : Strategy
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
            //if (SelfControl.DistanceTo(World.Width / 2, World.Height / 2) > 200)
            //{
            //    SelfControl.TurnTo(World.Width / 2, World.Height / 2);
            //}
            //else
            //{
            //    SelfControl.TurnTo(0, 0);
            //}

            //if (new Random().Next(1) == 0)
            //{
            //    SelfControl.StepForward();
            //}
            //else
            {
                SelfControl.StepRight();
            }
        }
    }
}