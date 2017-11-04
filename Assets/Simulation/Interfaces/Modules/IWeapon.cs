namespace Simulation.Interfaces.Modules
{
    public interface IWeapon
    {
        int Damage { get; }
        float ShellSpeed { get; }
        int Cooldown { get; }
    }
}