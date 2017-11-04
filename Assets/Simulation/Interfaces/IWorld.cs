using System.Collections.Generic;

namespace Simulation.Interfaces
{
    public interface IWorld
    {
        IList<IObstacle> Obstacles { get; }
        IList<IPlayer> Players { get; }
        IList<IShell> Shells { get; }
        IList<IMonster> Monsters { get; }

        float Height { get; }
        float Width { get; }

        int Tick { get; }
    }
}
