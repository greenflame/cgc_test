namespace Simulation.Interfaces
{
    public interface IDestroyableUnit : IUnit
    {
        int Health { get; }
        int MaxHealth { get; }
    }
}