namespace Simulation.Interfaces
{
    public interface IObstacle : IUnit
    {
        int RemainingStrength { get; }
    }
}