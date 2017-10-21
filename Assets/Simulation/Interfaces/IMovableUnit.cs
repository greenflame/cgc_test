namespace Simulation.Interfaces
{
    public interface IMovableUnit : IUnit
    {
        float LeftSpeed { get; }
        float RightSpeed { get; }
        float ForwardSpeed { get; }
        float BackSpeed { get; }

        float RotationSpeed { get; }
    }
}