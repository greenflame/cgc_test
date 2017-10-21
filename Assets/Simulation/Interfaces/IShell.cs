using Simulation.Interfaces.Enums;

namespace Simulation.Interfaces
{
    public interface IShell : IMovableUnit
    {
        ShellType ShellType { get; }
    }
}