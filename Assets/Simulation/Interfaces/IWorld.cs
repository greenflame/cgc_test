using System.Collections.Generic;

namespace Simulation.Interfaces
{
    public interface IWorld
    {
        IList<IBonus> Bonuses { get; }
        IList<IObstacle> Obstacles { get; }
        IList<IPlayer> Enemies { get; }
        IList<IShell> Shells { get; }

        float Height { get; }
        float Width { get; }

        int Tick { get; }
    }
}
