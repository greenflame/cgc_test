namespace Simulation.Interfaces.Modules
{
    public interface IUnitWithWeapon : IUnit
    {
        IWeapon Weapon { get; }
    }
}