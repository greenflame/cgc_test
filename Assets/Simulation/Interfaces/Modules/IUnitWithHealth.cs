namespace Simulation.Interfaces.Modules
{
    public interface IUnitWithHealth : IUnit
    {
        IHealth Health { get; }
    }
}