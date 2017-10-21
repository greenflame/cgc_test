using Simulation.Interfaces.Enums;

namespace Simulation.Interfaces
{
    public interface IEffect
    {
        int RemainingDuration();
        EffectType EffectType { get; }
    }
}