using System.Collections.Generic;
using Simulation.Interfaces.Enums;
using Simulation.Interfaces.Modules;

namespace Simulation.Interfaces
{
    public interface IPlayer : IMovableUnit, IUnitWithHealth, IUnitWithWeapon
    {
        string Name { get; }
        PlayerType PlayerType { get; }
        int Score { get; }
    }
}