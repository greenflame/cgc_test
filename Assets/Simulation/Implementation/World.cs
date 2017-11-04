using System.Collections.Generic;
using System.Linq;
using Simulation.Implementation.Geometry;
using Simulation.Interfaces;
using Simulation.Interfaces.Enums;
using Simulation.Strategies;

namespace Simulation.Implementation
{
    public class World
    {
        public List<GameObject> GameObjects { get; set; }

        public Vector2 Size { get; private set; }
        public int Tick { get; private set; }

        public World()
        {
            Size = new Vector2(1000, 750);
            Tick = 0;

            GameObjects = new List<GameObject>();
        }

        public void DoStep()
        {
            GameObjects.ForEach(obj => obj.DoStep());
            Tick++;
        }
    }
}