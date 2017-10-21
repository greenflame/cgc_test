using System.Collections.Generic;
using Simulation.Interfaces.Enums;

namespace Simulation.Interfaces
{
    public interface IEnemy : IMovableUnit
    {
        string Name { get; }
        PlayerType PlayerType { get; }

        IList<IEffect> Effects { get; }
        bool HasEffectOfType(IEffect effectType);
    }
}