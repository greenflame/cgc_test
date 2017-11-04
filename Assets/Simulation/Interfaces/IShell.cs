using Simulation.Interfaces.Enums;
using Simulation.Interfaces.Modules;

namespace Simulation.Interfaces
{
    public interface IShell : IMovableUnit
    {
        int Damage { get; }
    }
}