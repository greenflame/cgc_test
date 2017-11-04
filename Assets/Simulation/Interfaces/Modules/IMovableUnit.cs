namespace Simulation.Interfaces.Modules
{
    public interface IMovableUnit : IUnit
    {
        IMotionController MotionController { get; }
    }
}