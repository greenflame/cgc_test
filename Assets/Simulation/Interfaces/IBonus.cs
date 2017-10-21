using Simulation.Interfaces.Enums;

namespace Simulation.Interfaces
{
    public interface IBonus : IUnit
    {
        BonusType BonusType { get; }
    }
}