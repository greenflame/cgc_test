using System.Collections.Generic;

namespace Simulation.Interfaces
{
    public interface IWorld
    {
        IList<IObstacle> Obstacles { get; }
        IList<IPlayer> Players { get; }
        IList<IShell> Shells { get; }
        IList<IMonster> Monsters { get; }

        double Height { get; }
        double Width { get; }

        int Tick { get; }
    }
}
