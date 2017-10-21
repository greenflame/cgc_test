using System.Collections.Generic;
using System.Linq;
using Simulation.Interfaces;
using Simulation.Interfaces.Enums;
using Simulation.Strategies;

namespace Simulation.Implementation
{
    public class World : IWorld
    {
        public List<Player> Players { get; private set; }

        public IList<IBonus> Bonuses { get; private set; }
        public IList<IObstacle> Obstacles { get; private set; }
        public IList<IEnemy> Enemies { get; private set; }
        public IList<IShell> Shells { get; private set; }

        public float Height { get; private set; }
        public float Width { get; private set; }
        public int Tick { get; private set; }

        public World()
        {
            Height = 750;
            Width = 1000;

            Players = new List<Player>();


            var blueSelfControl = new SelfControl
            {
                PlayerType = PlayerType.Blue,
                Position = new Vector2(500, 750)
            };

            var bluePlayer = new GoToCenter(this, blueSelfControl);
            Players.Add(bluePlayer);
        }

        public void DoStep()
        {
            Players.Select(p => p.SelfControl as SelfControl)
                .ToList()
                .ForEach(s => s.ResetActions());

            Players.ForEach(s => s.Move());

            Players.Select(p => p.SelfControl as SelfControl)
                .ToList()
                .ForEach(s => s.ProcessActions());
        }
    }
}