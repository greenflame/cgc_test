using System.Collections.Generic;
using Simulation.Interfaces.Enums;

namespace Simulation.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        PlayerType PlayerType { get; }
        int Score { get; }
    }
}